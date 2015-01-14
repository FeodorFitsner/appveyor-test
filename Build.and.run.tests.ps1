Set-StrictMode -Version Latest

function Run-Command([scriptblock]$Command) {
    $output = ""
    & $Command

    $exitCode = 0
    if ($LastExitCode -ne 0) {
        $exitCode = $LastExitCode
    } elseif (!$?) {
        $exitCode = 1
    } else {
        return
    }

    $error = "``$Command`` failed"

    if ($output) {
        Write-Host -ForegroundColor "Red" $output
        $error += ". See output above."
    }

    Throw $error
}

function Build-Solution($slnPath) {

    Write-Host -ForegroundColor "Green" "Building solution..."

    Run-Command { & "$env:SystemRoot\Microsoft.NET\Framework\v4.0.30319\msbuild.exe" "$slnPath" /maxcpucount:3 /p:Configuration=Release /p:VisualStudioVersion=12.0 }
}

function Clean-OutputFolder($binReleaseFolder) {

    If (Test-Path $binReleaseFolder) {
        Write-Host -ForegroundColor "Green" "Removing `"$binReleaseFolder`" folder..."

        Run-Command { & Remove-Item -Recurse -Force "$binReleaseFolder" }

        Write-Host "Done."
    }
}

######################

$root = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition
$slnPath = Join-Path $root "Core.sln"

Clean-OutputFolder (Join-Path $root "Core\bin")
Clean-OutputFolder (Join-Path $root "Core\obj")
Clean-OutputFolder (Join-Path $root "Core.Tests\bin")
Clean-OutputFolder (Join-Path $root "Core.Tests\obj")

Build-Solution $slnPath

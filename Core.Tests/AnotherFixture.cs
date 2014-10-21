using Xunit;

namespace Core.Tests
{
    public class AnotherFixture
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(3, Core.Random.Generate() - 1);
        }
    }
}

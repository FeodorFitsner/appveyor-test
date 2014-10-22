using Xunit;

namespace Core.Tests
{
    public class Fixture
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(6, Core.Random.Generate());
        }
    }
}

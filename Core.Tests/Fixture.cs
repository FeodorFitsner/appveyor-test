﻿using Xunit;

namespace Core.Tests
{
    public class Fixture
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(17, Core.Random.Generate());
        }

        [Fact]
        public void Test()
        {
            Assert.Equal(16, Core.Random.Generate() - 1);
        }
    }
}

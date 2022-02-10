using System;
using Xunit;

namespace FastNumber.Tests
{
    public class Add
    {
        [Fact]
        public void Negative()
        {
            FastNumbers nc = new();

            Assert.Throws<ArgumentOutOfRangeException>(() => nc.Add(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => nc.Add(int.MinValue));
        }

        [Fact]
        public void Duplicate()
        {
            FastNumbers nc = new();

            nc.Add(1);
            Assert.Throws<InvalidOperationException>(() => nc.Add(1));
        }
    }
}
using System;
using System.Linq;
using Xunit;

namespace FastNumber.Tests
{
    public class Remove
    {
        [Fact]
        public void Static()
        {
            FastNumbers nc = new(Enumerable.Range(1, 10));

            nc.Remove(5);
            Assert.Throws<InvalidOperationException>(() => nc.Remove(0));
            nc.Remove(10);
            Assert.Throws<ArgumentOutOfRangeException>(() => nc.Remove(-1));
        }

        [Fact]
        public void Dynamic()
        {
            FastNumbers nc = new();

            nc.Add(1);
            nc.Add(5);
            nc.Add(10);

            nc.Remove(5);
            Assert.Throws<InvalidOperationException>(() => nc.Remove(0));
            nc.Remove(10);
            Assert.Throws<ArgumentOutOfRangeException>(() => nc.Remove(-1));
        }
    }
}
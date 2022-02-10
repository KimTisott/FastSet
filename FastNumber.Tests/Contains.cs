using System;
using System.Linq;
using Xunit;

namespace FastNumber.Tests
{
    public class Contains
    {
        [Fact]
        public void Static()
        {
            FastNumbers nc = new(Enumerable.Range(1, 10));

            Assert.True(nc.Contains(5));
            Assert.False(nc.Contains(0));
            Assert.True(nc.Contains(10));
        }

        [Fact]
        public void Dynamic()
        {
            FastNumbers nc = new();

            nc.Add(1);
            nc.Add(5);
            nc.Add(10);

            Assert.True(nc.Contains(5));
            Assert.False(nc.Contains(0));
            Assert.True(nc.Contains(10));
        }
    }
}
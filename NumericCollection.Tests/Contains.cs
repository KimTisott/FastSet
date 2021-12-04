using System;
using System.Linq;
using Xunit;

namespace FastestCollections.Tests
{
    public class Contains
    {
        [Fact]
        public void Unit()
        {
            NumericCollection nc = new(Enumerable.Range(default, 3));

            Assert.True(nc.Contains(default));
            Assert.False(nc.Contains(int.MinValue));
            Assert.False(nc.Contains(int.MaxValue));
            Assert.False(nc.Contains(3));
            Assert.True(nc.Contains(2));
        }
    }
}
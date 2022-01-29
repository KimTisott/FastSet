using System;
using System.Linq;
using Xunit;

namespace NumericCollection.Tests
{
    public class Remove
    {
        [Fact]
        public void Unit()
        {
            NumericCollection nc = new(Enumerable.Range(default, 3));

            Assert.False(nc.Remove(int.MinValue));
            Assert.False(nc.Remove(int.MaxValue));
            Assert.True(nc.Remove(default));
            Assert.False(nc.Remove(default));
            Assert.True(nc.Remove(2));
        }
    }
}
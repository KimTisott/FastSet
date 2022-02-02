using System;
using Xunit;

namespace NumericCollection.Tests
{
    public class Add
    {
        [Fact]
        public void Negative()
        {
            NumericCollection nc = new(int.MaxValue);

            Assert.Throws<ArgumentOutOfRangeException>(() => nc.Add(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => nc.Add(int.MinValue));
        }

        [Fact]
        public void Duplicate()
        {
            NumericCollection nc = new(int.MaxValue);

            nc.Add(1);
            Assert.Throws<InvalidOperationException>(() => nc.Add(1));
        }
    }
}
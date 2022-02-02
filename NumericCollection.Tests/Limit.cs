using System;
using System.Linq;
using Xunit;

namespace NumericCollection.Tests
{
    public class Limit
    {
        [Fact]
        public void Min()
        {
            var nc = new NumericCollection(1);

            nc.Add(1);

            Assert.Throws<ArgumentOutOfRangeException>(() => nc.Add(2));
        }

        [Fact]
        public void Max()
        {
            var nc = new NumericCollection(int.MaxValue - 1);

            foreach (var number in Enumerable.Range(0, int.MaxValue))
                nc.Add(number);

            Assert.Throws<ArgumentOutOfRangeException>(() => nc.Add(int.MaxValue));
        }
    }
}
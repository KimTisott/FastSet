using System;
using System.Linq;
using Xunit;

namespace NumericCollection.Tests
{
    public class Remove
    {
        readonly NumericCollection staticData = new(Enumerable.Range(1, 10));

        [Fact]
        public void Static()
        {
            staticData.Remove(5);
            Assert.Throws<InvalidOperationException>(() => staticData.Remove(0));
            staticData.Remove(10);
            Assert.Throws<ArgumentOutOfRangeException>(() => staticData.Remove(-1));
        }

        [Fact]
        public void Dynamic()
        {
            NumericCollection dynamicData = new();
            dynamicData.Add(1);
            dynamicData.Add(5);
            dynamicData.Add(10);

            dynamicData.Remove(5);
            Assert.Throws<InvalidOperationException>(() => dynamicData.Remove(0));
            dynamicData.Remove(10);
            Assert.Throws<ArgumentOutOfRangeException>(() => staticData.Remove(-1));
        }
    }
}
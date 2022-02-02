using System;
using System.Linq;
using Xunit;

namespace NumericCollection.Tests
{
    public class Contains
    {
        readonly NumericCollection staticData = new(Enumerable.Range(1, 10));

        [Fact]
        public void Static()
        {
            Assert.True(staticData.Contains(5));
            Assert.False(staticData.Contains(0));
            Assert.True(staticData.Contains(10));
        }

        [Fact]
        public void Dynamic()
        {
            NumericCollection dynamicData = new();
            dynamicData.Add(1);
            dynamicData.Add(5);
            dynamicData.Add(10);

            Assert.True(dynamicData.Contains(5));
            Assert.False(dynamicData.Contains(0));
            Assert.True(dynamicData.Contains(10));
        }
    }
}
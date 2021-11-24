using System;
using System.Linq;
using Xunit;

namespace FastestCollections.Tests
{
    public class Unit
    {
        [Fact]
        public void Add()
        {
            NumericCollection nc = new();

            Assert.False(nc.TryAdd(int.MinValue));
            Assert.True(nc.TryAdd(default));
            Assert.True(nc.TryAdd(int.MaxValue));
            Assert.False(nc.TryAdd(default));
            Assert.Throws<ArgumentOutOfRangeException>(() => nc = new(new int[] { int.MinValue, default, int.MaxValue }));
        }

        [Fact]
        public void Contains()
        {
            NumericCollection nc = new(Enumerable.Range(default, 3));

            Assert.True(nc.Contains(default));
            Assert.False(nc.Contains(int.MinValue));
            Assert.False(nc.Contains(int.MaxValue));
            Assert.False(nc.Contains(3));
            Assert.True(nc.Contains(2));
        }

        [Fact]
        public void Remove()
        {
            NumericCollection nc = new(Enumerable.Range(default, 3));

            Assert.False(nc.TryRemove(int.MinValue));
            Assert.False(nc.TryRemove(int.MaxValue));
            Assert.True(nc.TryRemove(default));
            Assert.False(nc.TryRemove(default));
            Assert.True(nc.TryRemove(2));
        }
    }
}

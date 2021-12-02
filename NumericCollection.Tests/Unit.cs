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

            Assert.Throws<ArgumentOutOfRangeException>(() => nc.TryAdd(int.MinValue));
            Assert.True(nc.TryAdd(default));
            Assert.True(nc.TryAdd(int.MaxValue));
            Assert.False(nc.TryAdd(default));
            Assert.Throws<ArgumentOutOfRangeException>(() => nc = new(new int[] { int.MinValue, default, int.MaxValue }));
        }

        [Fact]
        public void Contains()
        {
            NumericCollection nc = new(Enumerable.Range(default, 3));

            Assert.True(nc.TryContains(default));
            Assert.Throws<ArgumentOutOfRangeException>(() => nc.TryContains(int.MinValue));
            Assert.False(nc.TryContains(int.MaxValue));
            Assert.False(nc.TryContains(3));
            Assert.True(nc.TryContains(2));
        }

        [Fact]
        public void Remove()
        {
            NumericCollection nc = new(Enumerable.Range(default, 3));

            Assert.Throws<ArgumentOutOfRangeException>(() => nc.TryRemove(int.MinValue));
            Assert.False(nc.TryRemove(int.MaxValue));
            Assert.True(nc.TryRemove(default));
            Assert.False(nc.TryRemove(default));
            Assert.True(nc.TryRemove(2));
        }

        [Fact]
        public void Lookup()
        {
            NumericCollection nc = new(Enumerable.Range(default, 3));

            Assert.Throws<ArgumentOutOfRangeException>(() => nc[-1]);
            Assert.True(nc[0]);
            Assert.True(nc[2]);
            Assert.False(nc[3]);
            Assert.False(nc[int.MaxValue]);
        }
    }
}
using System;
using Xunit;

namespace FastestCollections.Tests
{
    public class Unit
    {
        [Fact]
        public void Add()
        {
            NumericCollection<int> set = new();

            Assert.False(set.TryAdd(int.MinValue));
            Assert.True(set.TryAdd(default));
            Assert.True(set.TryAdd(int.MaxValue));
            Assert.False(set.TryAdd(default));
            Assert.Throws<ArgumentOutOfRangeException>(() => set = new(new int[] { int.MinValue, default, int.MaxValue }));
        }

        [Fact]
        public void Contains()
        {
            NumericCollection<int> set = new(NumericCollection.Range(default, 3));

            Assert.True(set.Contains(default));
            Assert.False(set.Contains(int.MinValue));
            Assert.False(set.Contains(int.MaxValue));
            Assert.False(set.Contains(3));
            Assert.True(set.Contains(2));
        }

        [Fact]
        public void Remove()
        {
            NumericCollection<int> set = new(NumericCollection.Range(default, 3));

            Assert.False(set.TryRemove(int.MinValue));
            Assert.False(set.TryRemove(int.MaxValue));
            Assert.True(set.TryRemove(default));
            Assert.False(set.TryRemove(default));
            Assert.True(set.TryRemove(2));
        }
    }
}

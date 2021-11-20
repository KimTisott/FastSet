using System;
using Xunit;

namespace FastSet.Tests
{
    public class Unit
    {
        [Fact]
        public void Int32_Add()
        {
            FastSet_Int32 set = new();

            Assert.False(set.TryAdd(int.MinValue));
            Assert.True(set.TryAdd(default));
            Assert.True(set.TryAdd(int.MaxValue));
            Assert.False(set.TryAdd(default));
            Assert.Throws<ArgumentOutOfRangeException>(() => set = new(new int[] { int.MinValue, default, int.MaxValue }));
        }

        [Fact]
        public void Int32_Contains()
        {
            FastSet_Int32 set = new(FastSet.Range_Int32(default, 3));

            Assert.True(set.Contains(default));
            Assert.False(set.Contains(int.MinValue));
            Assert.False(set.Contains(int.MaxValue));
            Assert.False(set.Contains(3));
            Assert.True(set.Contains(2));
        }

        [Fact]
        public void Int32_Remove()
        {
            FastSet_Int32 set = new(FastSet.Range_Int32(default, 3));

            Assert.False(set.TryRemove(int.MinValue));
            Assert.False(set.TryRemove(int.MaxValue));
            Assert.True(set.TryRemove(default));
            Assert.False(set.TryRemove(default));
            Assert.True(set.TryRemove(2));
        }
    }
}

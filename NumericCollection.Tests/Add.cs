using System;
using Xunit;

namespace NumericCollection.Tests
{
    public class Add
    {
        readonly NumericCollection unlimited = new();
        readonly NumericCollection limited = new(2);

        [Fact]
        public void Negative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => unlimited.Add(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => unlimited.Add(int.MinValue));
        }

        [Fact]
        public void Duplicate()
        {
            unlimited.Add(1);
            Assert.Throws<InvalidOperationException>(() => unlimited.Add(1));
        }

        [Fact]
        public void Limit()
        {
            limited.Add(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => limited.Add(10));
            limited.Add(2);
        }
    }
}
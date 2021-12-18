using Xunit;

namespace FastestCollections.Tests
{
    public class Add
    {
        [Fact]
        public void Unit()
        {
            NumericCollection nc = new();

            Assert.False(nc.Add(int.MinValue));
            Assert.True(nc.Add(default));
            Assert.True(nc.Add(int.MaxValue));
            Assert.False(nc.Add(default));
            Assert.False(nc.Add(int.MinValue));
        }
    }
}
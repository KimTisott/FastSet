using System.Linq;
using Xunit;

namespace FastNumber.Tests
{
    public class Index
    {
        [Fact]
        public void Explicit()
        {
            FastNumbers nc = new(Enumerable.Range(5, 10));

            Assert.False(nc[0]);
            Assert.False(nc[4]);
            Assert.True(nc[5]);
            Assert.True(nc[7]);
            Assert.True(nc[10]);
        }

        [Fact]
        public void Enumeration()
        {
            FastNumbers nc = new(Enumerable.Range(0, 1000));

            var count = 0;
            foreach (var item in nc)
                Assert.Equal(count++, item);
            Assert.False(nc[1000]);
        }
    }
}
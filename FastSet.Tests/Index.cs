using System.Linq;
using Xunit;

namespace FastSet.Tests;

public class Index
{
    [Fact]
    public void Explicit()
    {
        FastSet test = new(Enumerable.Range(5, 10));

        Assert.False(test[0]);
        Assert.False(test[4]);
        Assert.True(test[5]);
        Assert.True(test[7]);
        Assert.True(test[10]);
    }

    [Fact]
    public void Enumeration()
    {
        FastSet test = new(Enumerable.Range(0, 1000));

        var count = 0;
        foreach (var item in test)
            Assert.Equal(count++, item);
        Assert.False(test[1000]);
    }
}
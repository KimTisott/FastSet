using System.Linq;
using Xunit;

namespace FastSet.Tests;

public class Limit
{
    [Fact]
    public void Min()
    {
        var test = new FastSet(1);

        Assert.True(test.TryAdd(1));
        Assert.False(test.TryAdd(2));
    }

    [Fact]
    public void Max()
    {
        var test = new FastSet(1000);

        foreach (var number in Enumerable.Range(0, 1000))
            Assert.True(test.TryAdd(number));
        Assert.False(test.TryAdd(1001));
    }
}
using System.Linq;
using Xunit;

namespace FastSet.Tests;

public class Remove
{
    [Fact]
    public void Static()
    {
        FastSet test = new(Enumerable.Range(1, 10));

        Assert.True(test.TryRemove(5));
        Assert.False(test.TryRemove(0));
        Assert.True(test.TryRemove(10));
        Assert.False(test.TryRemove(-1));
    }

    [Fact]
    public void Dynamic()
    {
        FastSet test = new();

        Assert.True(test.TryAdd(1));
        Assert.True(test.TryAdd(5));
        Assert.True(test.TryAdd(10));
        Assert.True(test.TryRemove(5));
        Assert.False(test.TryRemove(0));
        Assert.True(test.TryRemove(10));
        Assert.False(test.TryRemove(-1));
    }
}
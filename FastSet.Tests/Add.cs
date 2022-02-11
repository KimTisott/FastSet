using Xunit;

namespace FastSet.Tests;

public class Add
{
    [Fact]
    public void Negative()
    {
        FastSet test = new();

        Assert.False(test.TryAdd(-1));
        Assert.False(test.TryAdd(int.MinValue));
    }

    [Fact]
    public void Duplicate()
    {
        FastSet test = new();

        Assert.True(test.TryAdd(1));
        Assert.False(test.TryAdd(1));
    }
}
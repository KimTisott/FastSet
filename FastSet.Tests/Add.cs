using System;
using Xunit;

namespace FastSet.Tests;

public class Add
{
    [Fact]
    public void Negative()
    {
        FastSet nc = new();

        Assert.Throws<ArgumentOutOfRangeException>(() => nc.Add(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => nc.Add(int.MinValue));
    }

    [Fact]
    public void Duplicate()
    {
        FastSet nc = new();

        nc.Add(1);
        Assert.Throws<InvalidOperationException>(() => nc.Add(1));
    }
}
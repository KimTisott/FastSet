using System;
using System.Linq;
using Xunit;

namespace FastSet.Tests;

public class Contains
{
    [Fact]
    public void Static()
    {
        FastSet nc = new(Enumerable.Range(1, 10));

        Assert.True(nc.Contains(5));
        Assert.False(nc.Contains(0));
        Assert.True(nc.Contains(10));
    }

    [Fact]
    public void Dynamic()
    {
        FastSet nc = new();

        nc.Add(1);
        nc.Add(5);
        nc.Add(10);

        Assert.True(nc.Contains(5));
        Assert.False(nc.Contains(0));
        Assert.True(nc.Contains(10));
    }
}
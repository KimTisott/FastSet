using System;
using System.Linq;
using Xunit;

namespace FastSet.Tests;

public class Limit
{
    [Fact]
    public void Min()
    {
        var nc = new FastSet(1);

        nc.Add(1);

        Assert.Throws<ArgumentOutOfRangeException>(() => nc.Add(2));
    }

    [Fact]
    public void Max()
    {
        var nc = new FastSet(1000);

        foreach (var number in Enumerable.Range(0, 1000))
            nc.Add(number);

        Assert.Throws<ArgumentOutOfRangeException>(() => nc.Add(1001));
    }
}
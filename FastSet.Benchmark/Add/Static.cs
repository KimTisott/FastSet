using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace FastSet.Benchmarks.Add;

public class Static : Base
{
    [Benchmark]
    public void FastSet()
    {
        //var test = new FastSet(limit: RandomValues.Count());
        //foreach (var item in RandomValues)
        //    test.TryAdd(item);
    }

    [Benchmark(Baseline = true)]
    public void HashSet()
    {
        //var test = new HashSet<int>(RandomValues.Count());
        //foreach (var item in RandomValues)
        //    test.Add(item);
    }
}
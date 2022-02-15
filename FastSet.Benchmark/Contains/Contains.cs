using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace FastSet.Benchmarks;

public class Contains : Base
{
    [Benchmark]
    public void FastSet()
    {
        //var test = new FastSet(RandomValues);
        //foreach (var item in test)
        //    test.Contains(item);
    }

    [Benchmark(Baseline = true)]
    public void HashSet()
    {
        //var test = new HashSet<int>(RandomValues);
        //foreach (var item in test)
        //    test.Contains(item);
    }
}
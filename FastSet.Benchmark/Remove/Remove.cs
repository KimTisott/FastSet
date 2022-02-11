using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace FastSet.Benchmarks;

public class Remove : BaseBenchmark
{
    [Benchmark]
    public void FastSet()
    {
        var test = new FastSet(Enumerable.Range(0, Iterations));
        for (var i = 0; i < Iterations; i++)
            test.Remove(i);
    }

    [Benchmark(Baseline = true)]
    public void HashSet()
    {
        var test = new HashSet<int>(Enumerable.Range(0, Iterations));
        for (var i = 0; i < Iterations; i++)
            test.Remove(i);
    }
}
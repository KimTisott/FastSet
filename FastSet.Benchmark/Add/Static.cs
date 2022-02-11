using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace FastSet.Benchmarks.Add;

public class Static : BaseBenchmark
{
    [Benchmark]
    public void FastSet()
    {
        var test = new FastSet(limit: Iterations);
        for (var i = 0; i < Iterations; i++)
            test.TryAdd(i);
    }

    [Benchmark(Baseline = true)]
    public void HashSet()
    {
        var test = new HashSet<int>(Iterations);
        for (var i = 0; i < Iterations; i++)
            test.Add(i);
    }
}
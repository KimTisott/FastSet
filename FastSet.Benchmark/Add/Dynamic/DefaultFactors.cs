using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace FastSet.Benchmarks.Add.Dynamic;

public class DefaultFactors : BaseBenchmark
{
    [Benchmark]
    public void FastSet()
    {
        var test = new FastSet();
        for (var i = 0; i < Iterations; i++)
            test.TryAdd(i);
    }

    [Benchmark(Baseline = true)]
    public void HashSet()
    {
        var test = new HashSet<int>();
        for (var i = 0; i < Iterations; i++)
            test.Add(i);
    }
}
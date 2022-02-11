using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace FastSet.Benchmarks.Add;

public class Dynamic : BaseBenchmark
{
    [Benchmark]
    public void FastSet()
    {
        var test = new FastSet(growth: Growth);
        for (var i = 0; i < Iterations; i++)
            test.Add(i);
    }

    [Benchmark(Baseline = true)]
    public void HashSet()
    {
        var test = new HashSet<int>();
        for (var i = 0; i < Iterations; i++)
            test.Add(i);
    }

    [ParamsSource(nameof(GrowthValues))]
    public float Growth { get; set; }

    public IEnumerable<float> GrowthValues => new[] { 1.5f, 2.0f, 2.5f, 3.5f, 5.0f };
}
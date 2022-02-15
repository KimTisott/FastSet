using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace FastSet.Benchmarks.Add.Dynamic;

public class CustomFactors : Base
{
    [Benchmark]
    public void FastSet()
    {
        //var test = new FastSet(growth: Growth, load: Load);
        //foreach (var item in RandomValues)
        //    test.TryAdd(item);
    }

    [ParamsSource(nameof(GrowthValues))]
    public float Growth { get; set; }

    public IEnumerable<float> GrowthValues => new[] { 2.0f, 5.0f, 10.0f };

    [ParamsSource(nameof(LoadValues))]
    public float Load { get; set; }

    public IEnumerable<float> LoadValues => new[] { 0.5f, 0.75f, 1.0f };
}
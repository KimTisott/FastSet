using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace FastSet.Benchmarks.Add.Dynamic;

public class DefaultFactors : Base
{
    [Benchmark]
    public void FastSet()
    {
        //var test = new FastSet();
        //foreach (var item in RandomValues)
        //    test.TryAdd(item);
    }

    [Benchmark(Baseline = true)]
    public void HashSet()
    {
        //var test = new HashSet<int>();
        //foreach (var item in RandomValues)
        //    test.Add(item);
    }
}
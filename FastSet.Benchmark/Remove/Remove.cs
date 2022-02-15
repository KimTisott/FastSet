using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace FastSet.Benchmarks;

[BenchmarkCategory(nameof(RandomLimitedValues))]
public class Remove : Base
{
    [Benchmark]
    public void FastSet()
    {
        var test = new FastSet(RandomLimitedValues);
        foreach (var item in test)
            test.TryRemove(item);
    }

    [Benchmark(Baseline = true)]
    public void HashSet()
    {
        var test = new HashSet<int>(RandomLimitedValues);
        foreach (var item in test)
            test.Remove(item);
    }

    [Benchmark]
    [BenchmarkCategory(nameof(RandomUnlimitedValues))]
    public void FastSet_RandomUnlimited()
    {
        var test = new FastSet(RandomUnlimitedValues);
        foreach (var item in test)
            test.TryRemove(item);
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(nameof(RandomUnlimitedValues))]
    public void HashSet_RandomUnlimited()
    {
        var test = new HashSet<int>(RandomUnlimitedValues);
        foreach (var item in test)
            test.Remove(item);
    }

    [Benchmark]
    [BenchmarkCategory(nameof(SequentialValues))]
    public void FastSet_Sequential()
    {
        var test = new FastSet(SequentialValues);
        foreach (var item in test)
            test.TryRemove(item);
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(nameof(SequentialValues))]
    public void HashSet_Sequential()
    {
        var test = new HashSet<int>(SequentialValues);
        foreach (var item in test)
            test.Remove(item);
    }
}
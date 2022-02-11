using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace FastSet.Benchmarks;

[Config(typeof(Config))]
[SimpleJob(launchCount: 1, warmupCount: 5, targetCount: 5, baseline: true)]
[StopOnFirstError(false)]
public class BaseBenchmark
{
    [ParamsSource(nameof(IterationValues))]
    public int Iterations { get; set; }

    public IEnumerable<int> IterationValues => new[]
    {
        1,
        100,
        10_000,
        1_000_000,
        100_000_000
    };
}
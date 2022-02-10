using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System.Collections.Generic;

namespace FastNumber.Benchmarks
{
    [Config(typeof(Config))]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [SimpleJob(launchCount: 1, warmupCount: 5, targetCount: 5, baseline: true)]
    [StopOnFirstError(false)]
    public class BaseBenchmark
    {
        public static IEnumerable<object> Sizes()
        {
            yield return 1;
            yield return 100;
            yield return 10_000;
            yield return 1_000_000;
            yield return 100_000_000;
        }
    }
}
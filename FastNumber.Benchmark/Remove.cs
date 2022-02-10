using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace FastNumber.Benchmarks
{
    public class Remove : BaseBenchmark
    {
        [ArgumentsSource(nameof(Sizes))]
        [Benchmark(Description = "Numeric")]
        public void Numeric(int count)
        {
            var collection = new FastNumbers(Enumerable.Range(0, count));

            for (var i = 0; i < count; i++)
            {
                collection.Remove(i);
            }
        }

        [ArgumentsSource(nameof(Sizes))]
        [Benchmark(Baseline = true, Description = "HashSet")]
        public void HashSet(int count)
        {
            var set = new HashSet<int>(Enumerable.Range(0, count));

            for (var i = 0; i < count; i++)
            {
                set.Remove(i);
            }
        }
    }
}

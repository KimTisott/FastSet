using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace FastNumber.Benchmarks
{
    public class Add : BaseBenchmark
    {
        [ArgumentsSource(nameof(Sizes))]
        [Benchmark(Description = "Numeric")]
        [BenchmarkCategory("Dynamic")]
        public void Numeric_Dynamic(int count)
        {
            var collection = new FastNumbers();

            for (var i = 0; i < count; i++)
            {
                collection.Add(i);
            }
        }

        [ArgumentsSource(nameof(Sizes))]
        [Benchmark(Description = "Numeric")]
        [BenchmarkCategory("Static")]
        public void Numeric_Static(int count)
        {
            var collection = new FastNumbers(limit: count);

            for (var i = 0; i < count; i++)
            {
                collection.Add(i);
            }
        }

        [ArgumentsSource(nameof(Sizes))]
        [Benchmark(Baseline = true, Description = "HashSet")]
        [BenchmarkCategory("Dynamic")]
        public void HashSet_Dynamic(int count)
        {
            var hashSet = new HashSet<int>();

            for (var i = 0; i < count; i++)
            {
                hashSet.Add(i);
            }
        }

        [ArgumentsSource(nameof(Sizes))]
        [Benchmark(Baseline = true, Description = "HashSet")]
        [BenchmarkCategory("Static")]
        public void HashSet_Static(int count)
        {
            var hashSet = new HashSet<int>(count);

            for (var i = 0; i < count; i++)
            {
                hashSet.Add(i);
            }
        }
    }
}
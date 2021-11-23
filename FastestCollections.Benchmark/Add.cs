using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace FastestCollections.Benchmarks
{
    [BenchmarkCategory(nameof(Add))]
    public class Add : BenchmarkBase
    {
        [Benchmark]
        public void Fastest()
        {
            var collection = new NumericCollection<int>();

            for (int i = 0; i < Count; i++)
            {
                collection.TryAdd(i);
            }
        }

        [Benchmark]
        public void HashSet()
        {
            var hashSet = new HashSet<int>();

            for (int i = 0; i < Count; i++)
            {
                hashSet.Add(i);
            }
        }
    }
}
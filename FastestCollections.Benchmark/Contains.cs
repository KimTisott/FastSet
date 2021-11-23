using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace FastestCollections.Benchmarks
{
    [BenchmarkCategory(nameof(Contains))]
    public class Contains : BenchmarkBase
    {
        [Benchmark]
        public void Fastest()
        {
            var collection = new NumericCollection<int>(NumericCollection.Range(1, Count));

            for (int i = 0; i < Count; i++)
            {
                collection.Contains(i);
            }
        }

        [Benchmark]
        public void HashSet()
        {
            var set = new HashSet<int>(NumericCollection.Range(1, Count));

            for (int i = 0; i < Count; i++)
            {
                set.Contains(i);
            }
        }
    }
}
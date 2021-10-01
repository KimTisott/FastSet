using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace FastCollections.Benchmarks
{
    public class HashSet_Add : BenchmarkBase
    {
        [Benchmark, BenchmarkCategory("Add")]
        public void FastHashSet()
        {
            var fastHashSet = new FastHashSet();

            for (var i = 0; i < Size; i++)
            {
                fastHashSet.Add(i);
            }
        }

        [Benchmark, BenchmarkCategory("Add")]
        public void HashSet()
        {
            var hashSet = new HashSet<int>();

            for (var i = 0; i < Size; i++)
            {
                hashSet.Add(i);
            }
        }
    }
}
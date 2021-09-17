using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace FastCollections.Benchmarks.HashSet
{
    public class HashSet_Add : BenchmarkBase
    {
        [Benchmark, BenchmarkCategory("Add")]
        public void FastSet()
        {
            var fastSet = new FastSet();

            for (var i = 0; i < Size; i++)
            {
                fastSet.Add(i);
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
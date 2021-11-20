using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace FastSet.Benchmarks
{
    [BenchmarkCategory(nameof(Add))]
    public class Add : BenchmarkBase
    {
        [Benchmark]
        public void FastSet_Int32()
        {
            var fastSet = new FastSet_Int32();

            for (int i = 0; i < Count; i++)
            {
                fastSet.TryAdd(i);
            }
        }

        [Benchmark]
        public void FastSet_Int64()
        {
            var fastSet = new FastSet_Int64();

            for (long i = 0; i < Count; i++)
            {
                fastSet.TryAdd(i);
            }
        }

        [Benchmark]
        public void HashSet_Int32()
        {
            var hashSet = new HashSet<int>();

            for (int i = 0; i < Count; i++)
            {
                hashSet.Add(i);
            }
        }

        [Benchmark]
        public void HashSet_Int64()
        {
            var hashSet = new HashSet<long>();

            for (long i = 0; i < Count; i++)
            {
                hashSet.Add(i);
            }
        }
    }
}
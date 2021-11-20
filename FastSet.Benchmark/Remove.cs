using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace FastSet.Benchmarks
{
    [BenchmarkCategory(nameof(Remove))]
    public class Remove : BenchmarkBase
    {
        [Benchmark]
        public void FastSet_Int32()
        {
            var set = new FastSet_Int32(FastSet.Range_Int32(1, Count));

            for (int i = 0; i < Count; i++)
            {
                set.TryRemove(i);
            }
        }

        [Benchmark]
        public void FastSet_Int64()
        {
            var set = new FastSet_Int64(FastSet.Range_Int64(1, Count));

            for (long i = 0; i < Count; i++)
            {
                set.TryRemove(i);
            }
        }

        [Benchmark]
        public void HashSet_Int32()
        {
            var set = new HashSet<int>(FastSet.Range_Int32(1, Count));

            for (int i = 0; i < Count; i++)
            {
                set.Remove(i);
            }
        }

        [Benchmark]
        public void HashSet_Int64()
        {
            var set = new HashSet<long>(FastSet.Range_Int64(1, Count));

            for (long i = 0; i < Count; i++)
            {
                set.Remove(i);
            }
        }
    }
}

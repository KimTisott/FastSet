using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace FastSet.Benchmarks
{
    public class Int32 : BenchmarkBase
    {
        [Params(1, 100, 10000, 1000000)]
        public int Count { get; set; }

        [Benchmark]
        public void FastSet_Add()
        {
            var fastSet = new FastSet_Int32();

            for (var i = 0; i < Count; i++)
            {
                fastSet.TryAdd(i);
            }
        }

        [Benchmark]
        public void HashSet_Add()
        {
            var hashSet = new HashSet<int>();

            for (var i = 0; i < Count; i++)
            {
                hashSet.Add(i);
            }
        }

        [Benchmark]
        public void FastSet_Contains()
        {
            var set = new FastSet_Int32(Enumerable.Range(1, Count));

            for (var i = 0; i < Count; i++)
            {
                set.Contains(i);
            }
        }

        [Benchmark]
        public void HashSet_Contains()
        {
            var set = new HashSet<int>(Enumerable.Range(1, Count));

            for (var i = 0; i < Count; i++)
            {
                set.Contains(i);
            }
        }

        [Benchmark]
        public void FastSet_Remove()
        {
            var set = new FastSet_Int32(Enumerable.Range(1, Count));

            for (var i = 0; i < Count; i++)
            {
                set.Remove(i);
            }
        }

        [Benchmark]
        public void HashSet_Remove()
        {
            var set = new HashSet<int>(Enumerable.Range(1, Count));

            for (var i = 0; i < Count; i++)
            {
                set.Remove(i);
            }
        }
    }
}
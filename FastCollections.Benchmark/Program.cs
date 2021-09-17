using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using FastCollections;
using System.Collections.Generic;
using System.Linq;

namespace Performance
{
    class Program
    {
        static void Main()
        {
#if DEBUG
            var bench = new Bench();
            bench.FastSet();
            bench.HashSet();
#endif
            BenchmarkRunner.Run<Bench>();
        }
    }

    [CategoriesColumn, DisassemblyDiagnoser, MemoryDiagnoser, ReturnValueValidator]
    public class Bench
    {
        private readonly int Size = 1000000;
        private readonly FastSet FastSet = Enumerable.Range(0, 1000000).ToFastSet();
        private readonly HashSet<int> HashSet = Enumerable.Range(0, 1000000).ToHashSet();

        [Benchmark, BenchmarkCategory("Add")]
        public void FastSet_Add()
        {
            var fastSet = new FastSet();

            for (var i = 0; i < Size; i++)
            {
                fastSet.Add(i);
            }
        }

        [Benchmark, BenchmarkCategory("Add")]
        public void HashSet_Add()
        {
            var hashSet = new HashSet<int>();

            for (var i = 0; i < Size; i++)
            {
                hashSet.Add(i);
            }
        }

        [Benchmark, BenchmarkCategory("Contains")]
        public void FastSet_Contains()
        {
            for (var i = 0; i < Size; i++)
            {
                FastSet.Contains(i);
            }
        }

        [Benchmark, BenchmarkCategory("Contains")]
        public void HashSet_Contains()
        {
            for (var i = 0; i < Size; i++)
            {
                HashSet.Contains(i);
            }
        }

        [Benchmark, BenchmarkCategory("Remove")]
        public void FastSet_Remove()
        {
            for (var i = 0; i < Size; i++)
            {
                FastSet.Remove(i);
            }
        }

        [Benchmark, BenchmarkCategory("Remove")]
        public void HashSet_Remove()
        {
            for (var i = 0; i < Size; i++)
            {
                HashSet.Remove(i);
            }
        }
    }
}
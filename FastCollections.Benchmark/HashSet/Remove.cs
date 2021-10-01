using BenchmarkDotNet.Attributes;

namespace FastCollections.Benchmarks
{
    public class HashSet_Remove : BenchmarkBase
    {
        [Benchmark, BenchmarkCategory("Remove")]
        public void FastHashSet()
        {
            for (var i = 0; i < Size; i++)
            {
                FastHashSetData.Remove(i);
            }
        }

        [Benchmark, BenchmarkCategory("Remove")]
        public void HashSet()
        {
            for (var i = 0; i < Size; i++)
            {
                HashSetData.Remove(i);
            }
        }
    }
}
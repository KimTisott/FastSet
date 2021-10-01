using BenchmarkDotNet.Attributes;

namespace FastCollections.Benchmarks
{
    public class HashSet_Contains : BenchmarkBase
    {
        [Benchmark, BenchmarkCategory("Contains")]
        public void FastHashSet()
        {
            for (var i = 0; i < Size; i++)
            {
                FastHashSetData.Contains(i);
            }
        }

        [Benchmark, BenchmarkCategory("Contains")]
        public void HashSet()
        {
            for (var i = 0; i < Size; i++)
            {
                HashSetData.Contains(i);
            }
        }
    }
}
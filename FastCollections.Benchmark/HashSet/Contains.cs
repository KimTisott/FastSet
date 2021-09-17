using BenchmarkDotNet.Attributes;

namespace FastCollections.Benchmarks.HashSet
{
    public class HashSet_Contains : BenchmarkBase
    {
        [Benchmark, BenchmarkCategory("Contains")]
        public void FastSet()
        {
            for (var i = 0; i < Size; i++)
            {
                FastSetData.Contains(i);
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
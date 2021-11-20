using BenchmarkDotNet.Attributes;

namespace FastSet.Benchmarks
{
    public class HashSet_Remove : BenchmarkBase
    {
        [Benchmark, BenchmarkCategory("Remove")]
        public void FastSet()
        {
            for (var i = 0; i < Size; i++)
            {
                FastSetData.Remove(i);
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
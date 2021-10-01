using BenchmarkDotNet.Running;

namespace FastCollections.Benchmarks
{
    class Program
    {
        static void Main()
        {
#if DEBUG
            var bench = new BitArray_And();
            bench.BitArray();
            bench.FastBitArray();
#else
            BenchmarkRunner.Run<HashSet_Add>();
            BenchmarkRunner.Run<HashSet_Contains>();
            BenchmarkRunner.Run<HashSet_Remove>();
#endif
        }
    }
}
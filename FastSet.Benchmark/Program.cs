using BenchmarkDotNet.Running;

namespace FastSet.Benchmarks
{
    class Program
    {
        static void Main()
        {
#if DEBUG
            var bench = new Int32();
            bench.FastSet_Add();
#else
            BenchmarkRunner.Run<Int32>();
#endif
        }
    }
}
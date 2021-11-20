using BenchmarkDotNet.Running;

namespace FastSet.Benchmarks
{
    class Program
    {
        static void Main()
        {
#if DEBUG

#else
            BenchmarkRunner.Run<Int32>();
#endif
        }
    }
}
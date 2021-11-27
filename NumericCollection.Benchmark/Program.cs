using BenchmarkDotNet.Running;

namespace FastestCollections.Benchmarks
{
    class Program
    {
        static void Main()
        {
#if DEBUG

#else
            BenchmarkRunner.Run<Numeric.Add>();
            BenchmarkRunner.Run<Numeric.Contains>();
            BenchmarkRunner.Run<Numeric.Remove>();
#endif
        }
    }
}
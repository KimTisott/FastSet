using BenchmarkDotNet.Running;

namespace NumericCollection.Benchmarks
{
    class Program
    {
        static void Main()
        {
#if DEBUG

#else
            BenchmarkRunner.Run<Add>();
            //BenchmarkRunner.Run<Contains>();
            //BenchmarkRunner.Run<Remove>();
#endif
        }
    }
}
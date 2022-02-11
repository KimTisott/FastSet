using BenchmarkDotNet.Running;

namespace FastSet.Benchmarks;

class Program
{
    static void Main()
    {
#if DEBUG

#else
        BenchmarkRunner.Run<Add.Dynamic.CustomFactors>();
        BenchmarkRunner.Run<Add.Dynamic.DefaultFactors>();
        //BenchmarkRunner.Run<Add.Static>();
        //BenchmarkRunner.Run<Contains>();
        //BenchmarkRunner.Run<Remove>();
#endif
    }
}
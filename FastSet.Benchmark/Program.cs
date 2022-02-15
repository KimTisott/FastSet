using BenchmarkDotNet.Running;

namespace FastSet.Benchmarks;

class Program
{
    static void Main()
    {
#if DEBUG
        var test = new Remove();
        test.FastSet();
        test.HashSet();
#else
        //BenchmarkRunner.Run<Add.Dynamic.CustomFactors>();
        //BenchmarkRunner.Run<Add.Dynamic.DefaultFactors>();
        //BenchmarkRunner.Run<Add.Static>();
        //BenchmarkRunner.Run<Contains>();
        BenchmarkRunner.Run<Remove>();
#endif
    }
}
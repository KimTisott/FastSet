using BenchmarkDotNet.Running;
using FastCollections.Benchmarks.HashSet;

namespace FastCollections.Benchmarks
{
    class Program
    {
        static void Main()
        {
            BenchmarkRunner.Run<HashSet_Add>();
            BenchmarkRunner.Run<HashSet_Contains>();
            BenchmarkRunner.Run<HashSet_Remove>();
        }
    }
}
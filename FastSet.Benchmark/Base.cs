using BenchmarkDotNet.Attributes;

namespace FastSet.Benchmarks
{
    [DisassemblyDiagnoser, MemoryDiagnoser, ReturnValueValidator]
    public class BenchmarkBase
    {
        [Params(1, 1_000, 1_000_000)]
        public int Count { get; set; }
    }
}
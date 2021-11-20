using BenchmarkDotNet.Attributes;

namespace FastSet.Benchmarks
{
    [DisassemblyDiagnoser, MemoryDiagnoser, ReturnValueValidator]
    public class BenchmarkBase
    {
        
    }
}
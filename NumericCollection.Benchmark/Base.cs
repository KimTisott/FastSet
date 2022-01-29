using BenchmarkDotNet.Attributes;

namespace NumericCollection.Benchmarks
{
    [MemoryDiagnoser(false), ReturnValueValidator]
    public class BenchmarkBase
    {
        [Params(1, 1_000, 1_000_000, 1_000_000_000)]
        public int Count { get; set; }
    }
}
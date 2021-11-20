using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace FastSet.Benchmarks
{
    [CategoriesColumn, DisassemblyDiagnoser, MemoryDiagnoser, ReturnValueValidator]
    public class BenchmarkBase
    {
        public const int Size = 1000;
        public readonly FastSet FastSetData = Enumerable.Range(0, Size).ToFastSet();
        public readonly HashSet<int> HashSetData = Enumerable.Range(0, Size).ToHashSet();
    }
}
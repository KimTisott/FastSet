using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;

namespace FastNumber.Benchmarks
{
    internal class Config : ManualConfig
    {
        public Config()
        {
            AddColumn(CategoriesColumn.Default);
            AddColumn(BaselineRatioColumn.RatioMean);
            AddDiagnoser(new MemoryDiagnoser(new(false)));
            AddExporter(MarkdownExporter.GitHub);
        }
    }
}

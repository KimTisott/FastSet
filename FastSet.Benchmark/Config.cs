using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;

namespace FastSet.Benchmarks;

internal class Config : ManualConfig
{
    public Config()
    {
        ArtifactsPath = "../../../Reports";
        AddColumn(CategoriesColumn.Default);
        AddColumn(BaselineRatioColumn.RatioMean);
        AddDiagnoser(new MemoryDiagnoser(new(false)));
        AddExporter(MarkdownExporter.GitHub);
    }
}
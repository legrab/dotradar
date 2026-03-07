namespace DotRadar.Analyzer.Core;

[SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses",
    Justification = "Class is instantiated via dependency injection")]
internal sealed class AnalyzerFactory(Func<IEnumerable<IAnalyzer>> analyzers) : IAnalyzerFactory
{
    public Result<IAnalyzer?> CreateAnalyzer(AnalyzerType type, string name)
    {
        IAnalyzer? analyzer = analyzers()
            .FirstOrDefault(r => r.Type == type && r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (analyzer != null)
        {
            return analyzer.AsSuccess();
        }

        return new ResultException($"Analyzer with type {type} and name {name} not found.").AsFailure<IAnalyzer>();
    }

    public Result<IEnumerable<IAnalyzer>?> CreateAnalyzers(AnalyzerType? type = null)
    {
        IEnumerable<IAnalyzer> analyzersFiltered = analyzers();

        if (type != null)
        {
            analyzersFiltered = analyzersFiltered.Where(r => r.Type == type);
        }

        return analyzersFiltered.AsSuccess();
    }
}

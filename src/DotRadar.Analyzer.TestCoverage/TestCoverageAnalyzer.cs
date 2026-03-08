using DotRadar.Repository.Common.Interfaces;

namespace DotRadar.Analyzer.TestCoverage;

[SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses",
    Justification = "Class is instantiated via dependency injection")]
internal sealed class TestCoverageAnalyzer : IAnalyzer
{
    public string Name => "TestCoverage";
    public AnalyzerType Type => AnalyzerType.Quality;

    public AnalyzationResult Analyze(IRepository repository) =>
        new(AnalyzationProperties.Empty, ResultStatus.Failure, null,
            new NotImplementedException("TestCoverage analysis is not implemented yet."));
}

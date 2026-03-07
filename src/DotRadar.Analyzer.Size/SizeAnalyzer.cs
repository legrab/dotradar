using DotRadar.Analyzer.Common;
using DotRadar.Analyzer.Common.Enums;
using DotRadar.Common.Results;
using DotRadar.Repository.Common.Interfaces;

namespace DotRadar.Analyzer.Size;

[SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses",
    Justification = "Class is instantiated via dependency injection")]
internal sealed class SizeAnalyzer : IAnalyzer
{
    public string Name => "Size";
    public AnalyzerType Type => AnalyzerType.Complexity;

    public AnalyzationResult Analyze(IRepository repository) =>
        new(AnalyzationProperties.Empty, ResultStatus.Failure, null,
            new NotImplementedException("Size analysis is not implemented yet."));
}

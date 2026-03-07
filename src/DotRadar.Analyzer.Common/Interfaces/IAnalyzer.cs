using DotRadar.Analyzer.Common.Enums;
using DotRadar.Repository.Common.Interfaces;

namespace DotRadar.Analyzer.Common.Interfaces;

[UsedImplicitly(ImplicitUseTargetFlags.WithInheritors)]
public interface IAnalyzer
{
    public string Name { get; }
    public AnalyzerType Type { get; }

    public AnalyzationResult Analyze(IRepository repository);
}

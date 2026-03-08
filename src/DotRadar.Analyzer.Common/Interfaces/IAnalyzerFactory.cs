using DotRadar.Analyzer.Common.Enums;

namespace DotRadar.Analyzer.Common.Interfaces;

public interface IAnalyzerFactory
{
    Result<IAnalyzer?> CreateAnalyzer(AnalyzerType type, string name);
    Result<IEnumerable<IAnalyzer>?> CreateAnalyzers(AnalyzerType? type = null);
}

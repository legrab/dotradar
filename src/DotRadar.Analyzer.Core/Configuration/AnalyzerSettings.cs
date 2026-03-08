using DotRadar.Common.Domain.Configuration;

namespace DotRadar.Analyzer.Core.Configuration;

public class AnalyzerSettings
{
    public const string SectionName = "Analyzer";

    public AssemblyLoadSettings Assembly { get; set; } = new();

    public bool IsConfigured => Assembly.IsConfigured;
}

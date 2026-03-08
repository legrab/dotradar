using DotRadar.Common.Domain.Configuration;

namespace DotRadar.Repository.Core.Configuration;

public class RepositorySettings
{
    public const string SectionName = "Repository";

    public AssemblyLoadSettings Assembly { get; set; } = new();

    public bool IsConfigured => Assembly.IsConfigured;
}

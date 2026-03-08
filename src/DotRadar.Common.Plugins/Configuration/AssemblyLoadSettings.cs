namespace DotRadar.Common.Domain.Configuration;

public class AssemblyLoadSettings
{
    public string Directory { get; set; } = string.Empty;
    public string[] Patterns { get; set; } = [];

    public bool IsConfigured => Directory.NotNullOrEmpty() && Patterns.Length > 0;
}

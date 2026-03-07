namespace DotRadar.Analyzer.Common;

public class AnalyzationProperties
{
    public string? Severity { get; set; }
    public string? Category { get; set; }
    public string? Message { get; set; }
    public string? Details { get; set; }
    public Dictionary<string, object> AdditionalProperties { get; } = [];

    public static AnalyzationProperties Empty => new();

    public string ToCliString()
    {
        List<string> lines = new();
        if (Severity.NotNullOrEmpty())
        {
            lines.Add($"Severity: {Severity}");
        }

        if (Category.NotNullOrEmpty())
        {
            lines.Add($"Category: {Category}");
        }

        if (Message.NotNullOrEmpty())
        {
            lines.Add($"Message: {Message}");
        }

        if (Details.NotNullOrEmpty())
        {
            lines.Add($"Details: {Details}");
        }

        lines.AddRange(AdditionalProperties
            .Select(kv => $"{kv.Key}: {kv.Value}"));

        return string.Join(Environment.NewLine, lines);
    }
}

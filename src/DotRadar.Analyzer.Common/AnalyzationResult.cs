namespace DotRadar.Analyzer.Common;

public record AnalyzationResult : Result
{
    public AnalyzationResult(AnalyzationProperties properties,
        ResultStatus status, object? value = null, Exception? error = null)
        : base(status, value, error) =>
        Properties = properties;

    public AnalyzationProperties Properties { get; init; }

    public string ToCliString()
    {
        string statusLine = $"Status: {Status}";
        string? valueLine = Value != null ? $"Value: {Value}" : null;
        string? errorLine = Error != null ? $"Error: {Error.Message}" : null;

        string propertiesLines = Properties.ToCliString();

        return string.Join(Environment.NewLine,
            new[] { statusLine, valueLine, errorLine, propertiesLines }
                .WhereNotNull());
    }
}

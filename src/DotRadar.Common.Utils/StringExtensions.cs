using System.Diagnostics.CodeAnalysis;

namespace DotRadar.Common.Utils;

public static class StringExtensions
{
    public static bool IsNullOrEmpty([NotNullWhen(false)] this string? input) => string.IsNullOrEmpty(input);
    public static bool NotNullOrEmpty([NotNullWhen(true)] this string? input) => !string.IsNullOrEmpty(input);
    public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? input) => string.IsNullOrWhiteSpace(input);
    public static bool NotNullOrWhiteSpace([NotNullWhen(true)] this string? input) => !string.IsNullOrWhiteSpace(input);
}

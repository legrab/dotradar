using System.Reflection;
using System.Text.RegularExpressions;

namespace DotRadar.Common.Reflection.Helpers;

public static class ImplementationLoader
{
    public static IEnumerable<Assembly> GetLoadedAssemblies(
        string directoryPath, string[]? assemblyNameGlobs = null)
    {
        string resolvedPath = Path.IsPathRooted(directoryPath)
            ? directoryPath
            : Path.Combine(AppContext.BaseDirectory, directoryPath);

        if (!Directory.Exists(resolvedPath))
        {
            throw new DirectoryNotFoundException($"The specified directory does not exist: {resolvedPath}");
        }

        string[] dllFiles = Directory.GetFiles(resolvedPath, "*.dll");
        if (assemblyNameGlobs is not null && assemblyNameGlobs.Length > 0)
        {
            dllFiles =
            [
                .. dllFiles.Where(file =>
                    assemblyNameGlobs.Any(glob => IsGlobMatch(Path.GetFileName(file), glob)))
            ];
        }

        return dllFiles.Select(Assembly.LoadFrom);
    }

    private static bool IsGlobMatch(string fileName, string glob)
    {
        string regexPattern = "^" + Regex.Escape(glob)
            .Replace(@"\*", ".*")
            .Replace(@"\?", ".") + "$";
        return Regex.IsMatch(fileName, regexPattern, RegexOptions.IgnoreCase);
    }

    public static IEnumerable<Type> GetImplementationTypesForBaseType<TBaseType>(IEnumerable<Assembly> assemblies)
    {
        Type baseType = typeof(TBaseType);

        IEnumerable<Type> implementationTypes = assemblies.SelectMany(a => a.GetTypes())
            .Where(t => baseType.IsAssignableFrom(t) && !t.IsAbstract);

        return implementationTypes;
    }
}

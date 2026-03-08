using System.Reflection;
using DotRadar.Common.Domain.Configuration;
using DotRadar.Common.Reflection.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace DotRadar.Common.Domain.Helpers;

public static class ModuleRegistrar
{
    public static void RegisterModules<TModuleInterface>(this IServiceCollection services,
        AssemblyLoadSettings? settings)
    {
        if (settings is null || !settings.IsConfigured)
        {
            return;
        }

        IEnumerable<Assembly> assemblies = ImplementationLoader.GetLoadedAssemblies(
            settings.Directory, settings.Patterns);
        ImplementationLoader.GetImplementationTypesForBaseType<TModuleInterface>(assemblies)
            .ForEach(module => services.AddTransient(typeof(TModuleInterface), module));
    }
}

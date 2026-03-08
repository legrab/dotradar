using DotRadar.Analyzer.Core.Configuration;
using DotRadar.Repository.Core.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotRadar.Core.Configuration;

public static class CoreRegistrar
{
    public static void RegisterCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterRepositories(configuration);
        services.RegisterAnalyzers(configuration);
    }
}

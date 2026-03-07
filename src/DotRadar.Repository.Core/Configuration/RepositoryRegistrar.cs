using DotRadar.Common.Domain.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace DotRadar.Repository.Core.Configuration;

public static class RepositoryRegistrar
{
    public static void RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RepositorySettings>(configuration.GetSection(RepositorySettings.SectionName));

        services.AddSingleton<IRepositoryFactory, RepositoryFactory>();
        services.AddSingleton<Func<IEnumerable<IRepository>>>(serviceProvider =>
            serviceProvider.GetServices<IRepository>);

        RepositorySettings? repositorySettings =
            configuration.GetSection(RepositorySettings.SectionName).Get<RepositorySettings>();
        services.RegisterModules<IRepository>(repositorySettings?.Assembly);
    }
}

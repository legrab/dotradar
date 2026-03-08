using DotRadar.Common.Domain.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace DotRadar.Analyzer.Core.Configuration;

public static class AnalyzerRegistrar
{
    public static void RegisterAnalyzers(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AnalyzerSettings>(configuration.GetSection(AnalyzerSettings.SectionName));

        services.AddSingleton<IAnalyzerFactory, AnalyzerFactory>();
        services.AddSingleton<Func<IEnumerable<IAnalyzer>>>(serviceProvider =>
            serviceProvider.GetServices<IAnalyzer>);

        AnalyzerSettings? analyzerSettings =
            configuration.GetSection(AnalyzerSettings.SectionName).Get<AnalyzerSettings>();
        services.RegisterModules<IAnalyzer>(analyzerSettings?.Assembly);
    }
}

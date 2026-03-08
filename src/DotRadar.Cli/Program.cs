using DotRadar.Cli.RazorComponents;
using DotRadar.Core.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RazorConsole.Core;

IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args)
    .UseRazorConsole<AnalyzationResults>();

hostBuilder.ConfigureAppConfiguration((_, config) =>
{
    config.AddCommandLine(args);
    config.AddUserSecrets<Program>(true, true);
});

hostBuilder.ConfigureServices((context, services) =>
{
    services.AddSingleton(context.Configuration);
    services.RegisterCore(context.Configuration);
});

IHost host = hostBuilder.Build();
await host.RunAsync();

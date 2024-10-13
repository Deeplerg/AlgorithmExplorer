using System.Reflection;
using AlgorithmExplorer.Application.InputExecutors;
using AlgorithmExplorer.Application.Providers.InputExecutors;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlgorithmExplorer.Desktop;

public class Startup
{
    public IConfiguration ConfigureConfiguration()
    {
        var configBuilder = new ConfigurationBuilder();
        //configBuilder.AddJsonFile("config.json");
        var config = configBuilder.Build();

        return config;
    }
    
    public IServiceCollection ConfigureServices(IConfiguration config)
    {
        var services = new ServiceCollection();

        services.AddAlgorithms();
        
        services.AddTransient<ITimeAlgorithmRunner, TimeAlgorithmRunner>();

        services.AddInputExecutorProviderServices();

        services.AddTransient<IWindowActivator, WindowActivator>();

        //services.Configure<DisplayableAlgorithmOptions>(config.GetSection("displayableAlgorithmOptions"));

        return services;
    }

    public IServiceProvider BuildServiceProvider(IServiceCollection services)
    {
        return services.BuildServiceProvider();
    }
}
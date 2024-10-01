using System.Reflection;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.Sum;
using AlgorithmExplorer.Application.InputExecutors;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Application.Providers.InputExecutors;
using AlgorithmExplorer.Application.Validators.CoordinatorOptions;
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Algorithms.Sum;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.Sum;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AlgorithmExplorer.Desktop;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAlgorithms(this IServiceCollection services)
    {
        return services
            .AddSumAlgorithm();
    }
    
    public static IServiceCollection AddSumAlgorithm(this IServiceCollection services)
    {
        services.AddTransient<
            ICancellableAlgorithm<SumOptions, SumResult>,
            SumAlgorithm>();

        services.AddTransient<
            IDataGenerator<SumDataGeneratorOptions, SumOptions>,
            SumDataGenerator>();

        services.AddTransient<
            ICancellableCoordinator<SumCoordinatorOptions>,
            SumCoordinator>();

        services.AddTransient<
            IMapper<DisplayableOptionInputs, SumCoordinatorOptions>,
            SumCoordinatorOptionsMapper>();

        services.AddTransient<
            IValidator<SumCoordinatorOptions>,
            SumCoordinatorOptionsValidator>();
        
        return services;
    }

    public static IServiceCollection AddInputExecutorProviderServices(this IServiceCollection services)
    {
        services.AddSingleton<IInputExecutorTypeCollection, InputExecutorTypeCollection>(_ =>
        {
            var typeCollection = new InputExecutorTypeCollection();
            typeCollection.AddAllFromAssembly(Assembly.GetAssembly(typeof(IInputExecutor))!);

            return typeCollection;
        });
        services.AddSingleton<IInputExecutorProvider, InputExecutorProvider>();

        return services;
    }
}
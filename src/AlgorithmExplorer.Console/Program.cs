using System.Reflection;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.BitonicSort;
using AlgorithmExplorer.Application.ExecutionCoordinators.BubbleSort;
using AlgorithmExplorer.Application.ExecutionCoordinators.Const;
using AlgorithmExplorer.Application.ExecutionCoordinators.DefaultPow;
using AlgorithmExplorer.Application.ExecutionCoordinators.Gorner;
using AlgorithmExplorer.Application.ExecutionCoordinators.Kadane;
using AlgorithmExplorer.Application.ExecutionCoordinators.LIS;
using AlgorithmExplorer.Application.ExecutionCoordinators.MatrixMultiplication;
using AlgorithmExplorer.Application.ExecutionCoordinators.Multiplication;
using AlgorithmExplorer.Application.ExecutionCoordinators.Polynom;
using AlgorithmExplorer.Application.ExecutionCoordinators.QuickPow;
using AlgorithmExplorer.Application.ExecutionCoordinators.QuickSort;
using AlgorithmExplorer.Application.ExecutionCoordinators.RecursivePow;
using AlgorithmExplorer.Application.ExecutionCoordinators.SimplePow;
using AlgorithmExplorer.Application.ExecutionCoordinators.Sum;
using AlgorithmExplorer.Application.ExecutionCoordinators.TimSort;
using AlgorithmExplorer.Application.InputExecutors;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Application.Providers.InputExecutors;
using AlgorithmExplorer.Application.Validators.CoordinatorOptions;
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Algorithms.BitonicSort;
using AlgorithmExplorer.Core.Algorithms.BubbleSort;
using AlgorithmExplorer.Core.Algorithms.Const;
using AlgorithmExplorer.Core.Algorithms.DefaultPow;
using AlgorithmExplorer.Core.Algorithms.Gorner;
using AlgorithmExplorer.Core.Algorithms.Kadane;
using AlgorithmExplorer.Core.Algorithms.LIS;
using AlgorithmExplorer.Core.Algorithms.MatrixMultiplication;
using AlgorithmExplorer.Core.Algorithms.Multiplication;
using AlgorithmExplorer.Core.Algorithms.Polynom;
using AlgorithmExplorer.Core.Algorithms.QuickPow;
using AlgorithmExplorer.Core.Algorithms.QuickSort;
using AlgorithmExplorer.Core.Algorithms.RecursivePow;
using AlgorithmExplorer.Core.Algorithms.SimplePow;
using AlgorithmExplorer.Core.Algorithms.Sum;
using AlgorithmExplorer.Core.Algorithms.TimSort;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.BitonicSort;
using AlgorithmExplorer.Core.DataGenerators.BubbleSort;
using AlgorithmExplorer.Core.DataGenerators.Const;
using AlgorithmExplorer.Core.DataGenerators.DefaultPow;
using AlgorithmExplorer.Core.DataGenerators.Gorner;
using AlgorithmExplorer.Core.DataGenerators.Kadane;
using AlgorithmExplorer.Core.DataGenerators.LIS;
using AlgorithmExplorer.Core.DataGenerators.MatrixMultiplication;
using AlgorithmExplorer.Core.DataGenerators.Multiplication;
using AlgorithmExplorer.Core.DataGenerators.Polynom;
using AlgorithmExplorer.Core.DataGenerators.QuickPow;
using AlgorithmExplorer.Core.DataGenerators.QuickSort;
using AlgorithmExplorer.Core.DataGenerators.RecursivePow;
using AlgorithmExplorer.Core.DataGenerators.SimplePow;
using AlgorithmExplorer.Core.DataGenerators.Sum;
using AlgorithmExplorer.Core.DataGenerators.TimSort;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using DefaultPowDataGenerator = AlgorithmExplorer.Core.DataGenerators.DefaultPow.DefaultPowDataGenerator;

string filename = "config.json";
string position = "displayableAlgorithmOptions";

var configBuilder = new ConfigurationBuilder();
configBuilder.AddJsonFile(filename);
var config = configBuilder.Build();

var services = new ServiceCollection();

services.AddAlgorithms();

services.AddTransient<ICancellableAlgorithmRunner, CancellableAlgorithmRunner>();

services.AddSingleton<IInputExecutorTypeCollection, InputExecutorTypeCollection>(_ =>
{
    var typeCollection = new InputExecutorTypeCollection();
    typeCollection.AddAllFromAssembly(Assembly.GetAssembly(typeof(IInputExecutor))!);

    return typeCollection;
});
services.AddSingleton<IInputExecutorProvider, InputExecutorProvider>();

services.Configure<DisplayableAlgorithmOptions>(config.GetSection(position));

var provider = services.BuildServiceProvider();


var options = provider.GetRequiredService<IOptions<DisplayableAlgorithmOptions>>();

var algorithmNames = Enum.GetNames<AlgorithmType>();
Console.WriteLine("Available algorithms:");
foreach (var name in algorithmNames)
{
    Console.WriteLine(name);
}

Console.Write("Algorithm: ");
string algorithmInput = Console.ReadLine()!;
bool isParsed = Enum.TryParse(typeof(AlgorithmType), algorithmInput, ignoreCase: true, out object? algorithmObject);

if (!isParsed || algorithmObject is null || (AlgorithmType)algorithmObject == AlgorithmType.None)
{
    Console.WriteLine("No such algorithm!");
    return;
}
var algorithm = (AlgorithmType)algorithmObject;


var sumOption = options.Value.Algorithms.First(x => x.AlgorithmName == algorithm);
List<DisplayableOptionInput> inputOptions = new();
foreach (var dispayableOption in sumOption.DisplayableCoordinatorOptions)
{
    Console.Write("\n" + dispayableOption.DisplayName + ": ");
    string input = Console.ReadLine()!;
    inputOptions.Add(new DisplayableOptionInput(dispayableOption, input));
}
var inputs = new DisplayableOptionInputs(sumOption.AlgorithmName, inputOptions);


var executorProvider = provider.GetRequiredService<IInputExecutorProvider>();
var executor = executorProvider.GetByAlgorithm(algorithm)!;

executor.SetInput(inputs);
var validationResult = executor.ValidateInput();

if (!validationResult.IsValid)
{
    Console.WriteLine("Validation error!");
    foreach (var error in validationResult.Errors)
    {
        Console.WriteLine(error.ErrorMessage);
    }

    return;
}

var cts = new CancellationTokenSource();
var token = cts.Token;
//cts.CancelAfter(50);

bool isPrepared = await executor.PrepareDataAsync(token);
Console.WriteLine($"Prepared: {isPrepared}");

if (!isPrepared)
{
    Console.WriteLine("Preparation cancelled!");
    return;
}

var benchmarkResult = await executor.RunAsync(token);
Console.WriteLine($"Total Time: {benchmarkResult.TotalTimeElapsed}, " +
                  $"Average Time: {TimeSpan.FromTicks((long)benchmarkResult.AlgorithmResults.Average(x => x.TimeElapsed.Ticks))}");
                  
                  

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAlgorithms(this IServiceCollection services)
    {
        return services
            .AddSumAlgorithm()
            .AddMultiplicationAlgorithm()
            .AddPolynomAlgorithm()
            .AddGornerAlgorithm()
            .AddBubbleSortAlgorithm()
            .AddBitonicSortAlgorithm()
            .AddTimSortAlgorithm()
            .AddQuickSortAlgorithm()
            .AddDefaultPowAlgorithm()
            .AddSimplePowAlgorithm()
            .AddQuickPowAlgorithm()
            .AddRecursivePowAlgorithm()
            .AddMatrixMultiplicationAlgorithm()
            .AddKadaneAlgorithm()
            .AddConstAlgorithm()
            .AddLISAlgorithm();
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
    
    public static IServiceCollection AddMultiplicationAlgorithm(this IServiceCollection services)
    {
        services.AddTransient<
            ICancellableAlgorithm<MultiplicationOptions, MultiplicationResult>,
            MultiplicationAlgorithm>();

        services.AddTransient<
            IDataGenerator<MultiplicationDataGeneratorOptions, MultiplicationOptions>,
            MultiplicationDataGenerator>();

        services.AddTransient<
            ICancellableCoordinator<MultiplicationCoordinatorOptions>,
            MultiplicationCoordinator>();

        services.AddTransient<
            IMapper<DisplayableOptionInputs, MultiplicationCoordinatorOptions>,
            MultiplicationCoordinatorOptionsMapper>();

        services.AddTransient<
            IValidator<MultiplicationCoordinatorOptions>,
            MultiplicationCoordinatorOptionsValidator>();

        return services;
    }
    
    public static IServiceCollection AddPolynomAlgorithm(this IServiceCollection services)
    {
        services.AddTransient<
            ICancellableAlgorithm<PolynomOptions, PolynomResult>,
            PolynomAlgorithm>();

        services.AddTransient<
            IDataGenerator<PolynomDataGeneratorOptions, PolynomOptions>,
            PolynomDataGenerator>();

        services.AddTransient<
            ICancellableCoordinator<PolynomCoordinatorOptions>,
            PolynomCoordinator>();

        services.AddTransient<
            IMapper<DisplayableOptionInputs, PolynomCoordinatorOptions>,
            PolynomCoordinatorOptionsMapper>();

        services.AddTransient<
            IValidator<PolynomCoordinatorOptions>,
            PolynomCoordinatorOptionsValidator>();

        return services;
    }
    
    public static IServiceCollection AddGornerAlgorithm(this IServiceCollection services)
    {
        services.AddTransient<
            ICancellableAlgorithm<GornerOptions, GornerResult>,
            GornerAlgorithm>();

        services.AddTransient<
            IDataGenerator<GornerDataGeneratorOptions, GornerOptions>,
            GornerDataGenerator>();

        services.AddTransient<
            ICancellableCoordinator<GornerCoordinatorOptions>,
            GornerCoordinator>();

        services.AddTransient<
            IMapper<DisplayableOptionInputs, GornerCoordinatorOptions>,
            GornerCoordinatorOptionsMapper>();

        services.AddTransient<
            IValidator<GornerCoordinatorOptions>,
            GornerCoordinatorOptionsValidator>();

        return services;
    }
    
    public static IServiceCollection AddBubbleSortAlgorithm(this IServiceCollection services)
    {
        services.AddTransient<
            ICancellableAlgorithm<BubbleSortOptions, BubbleSortResult>,
            BubbleSortAlgorithm>();

        services.AddTransient<
            IDataGenerator<BubbleSortDataGeneratorOptions, BubbleSortOptions>,
            BubbleSortDataGenerator>();

        services.AddTransient<
            ICancellableCoordinator<BubbleSortCoordinatorOptions>,
            BubbleSortCoordinator>();

        services.AddTransient<
            IMapper<DisplayableOptionInputs, BubbleSortCoordinatorOptions>,
            BubbleSortCoordinatorOptionsMapper>();

        services.AddTransient<
            IValidator<BubbleSortCoordinatorOptions>,
            BubbleSortCoordinatorOptionsValidator>();

        return services;
    }
    
    public static IServiceCollection AddBitonicSortAlgorithm(this IServiceCollection services)
    {
        services.AddTransient<
            ICancellableAlgorithm<BitonicSortOptions, BitonicSortResult>,
            BitonicSortAlgorithm>();

        services.AddTransient<
            IDataGenerator<BitonicSortDataGeneratorOptions, BitonicSortOptions>,
            BitonicSortDataGenerator>();

        services.AddTransient<
            ICancellableCoordinator<BitonicSortCoordinatorOptions>,
            BitonicSortCoordinator>();

        services.AddTransient<
            IMapper<DisplayableOptionInputs, BitonicSortCoordinatorOptions>,
            BitonicSortCoordinatorOptionsMapper>();

        services.AddTransient<
            IValidator<BitonicSortCoordinatorOptions>,
            BitonicSortCoordinatorOptionsValidator>();

        return services;
    }
    
    public static IServiceCollection AddTimSortAlgorithm(this IServiceCollection services)
    {
        services.AddTransient<
            ICancellableAlgorithm<TimSortOptions, TimSortResult>,
            TimSortAlgorithm>();

        services.AddTransient<
            IDataGenerator<TimSortDataGeneratorOptions, TimSortOptions>,
            TimSortDataGenerator>();

        services.AddTransient<
            ICancellableCoordinator<TimSortCoordinatorOptions>,
            TimSortCoordinator>();

        services.AddTransient<
            IMapper<DisplayableOptionInputs, TimSortCoordinatorOptions>,
            TimSortCoordinatorOptionsMapper>();

        services.AddTransient<
            IValidator<TimSortCoordinatorOptions>,
            TimSortCoordinatorOptionsValidator>();

        return services;
    }
    
    public static IServiceCollection AddQuickSortAlgorithm(this IServiceCollection services)
    {
        services.AddTransient<
            ICancellableAlgorithm<QuickSortOptions, QuickSortResult>,
            QuickSortAlgorithm>();

        services.AddTransient<
            IDataGenerator<QuickSortDataGeneratorOptions, QuickSortOptions>,
            QuickSortDataGenerator>();

        services.AddTransient<
            ICancellableCoordinator<QuickSortCoordinatorOptions>,
            QuickSortCoordinator>();

        services.AddTransient<
            IMapper<DisplayableOptionInputs, QuickSortCoordinatorOptions>,
            QuickSortCoordinatorOptionsMapper>();

        services.AddTransient<
            IValidator<QuickSortCoordinatorOptions>,
            QuickSortCoordinatorOptionsValidator>();

        return services;
    }
    
    public static IServiceCollection AddDefaultPowAlgorithm(this IServiceCollection services)
    {
        services.AddTransient<
            ICancellableAlgorithm<DefaultPowOptions, DefaultPowResult>,
            DefaultPowAlgorithm>();

        services.AddTransient<
            IDataGenerator<DefaultPowDataGeneratorOptions, DefaultPowOptions>,
            DefaultPowDataGenerator>();

        services.AddTransient<
            ICancellableCoordinator<DefaultPowCoordinatorOptions>,
            DefaultPowCoordinator>();

        services.AddTransient<
            IMapper<DisplayableOptionInputs, DefaultPowCoordinatorOptions>,
            DefaultPowCoordinatorOptionsMapper>();

        services.AddTransient<
            IValidator<DefaultPowCoordinatorOptions>,
            DefaultPowCoordinatorOptionsValidator>();

        return services;
    }
    
    public static IServiceCollection AddSimplePowAlgorithm(this IServiceCollection services)
    {
        services.AddTransient<
            ICancellableAlgorithm<SimplePowOptions, SimplePowResult>,
            SimplePowAlgorithm>();

        services.AddTransient<
            IDataGenerator<SimplePowDataGeneratorOptions, SimplePowOptions>,
            SimplePowDataGenerator>();

        services.AddTransient<
            ICancellableCoordinator<SimplePowCoordinatorOptions>,
            SimplePowCoordinator>();

        services.AddTransient<
            IMapper<DisplayableOptionInputs, SimplePowCoordinatorOptions>,
            SimplePowCoordinatorOptionsMapper>();

        services.AddTransient<
            IValidator<SimplePowCoordinatorOptions>,
            SimplePowCoordinatorOptionsValidator>();

        return services;
    }
    
    public static IServiceCollection AddQuickPowAlgorithm(this IServiceCollection services)
    {
        services.AddTransient<
            ICancellableAlgorithm<QuickPowOptions, QuickPowResult>,
            QuickPowAlgorithm>();

        services.AddTransient<
            IDataGenerator<QuickPowDataGeneratorOptions, QuickPowOptions>,
            QuickPowDataGenerator>();

        services.AddTransient<
            ICancellableCoordinator<QuickPowCoordinatorOptions>,
            QuickPowCoordinator>();

        services.AddTransient<
            IMapper<DisplayableOptionInputs, QuickPowCoordinatorOptions>,
            QuickPowCoordinatorOptionsMapper>();

        services.AddTransient<
            IValidator<QuickPowCoordinatorOptions>,
            QuickPowCoordinatorOptionsValidator>();

        return services;
    }
    
    public static IServiceCollection AddRecursivePowAlgorithm(this IServiceCollection services)
    {
        services.AddTransient<
            ICancellableAlgorithm<RecursivePowOptions, RecursivePowResult>,
            RecursivePowAlgorithm>();

        services.AddTransient<
            IDataGenerator<RecursivePowDataGeneratorOptions, RecursivePowOptions>,
            RecursivePowDataGenerator>();

        services.AddTransient<
            ICancellableCoordinator<RecursivePowCoordinatorOptions>,
            RecursivePowCoordinator>();

        services.AddTransient<
            IMapper<DisplayableOptionInputs, RecursivePowCoordinatorOptions>,
            RecursivePowCoordinatorOptionsMapper>();

        services.AddTransient<
            IValidator<RecursivePowCoordinatorOptions>,
            RecursivePowCoordinatorOptionsValidator>();

        return services;
    }
    
    public static IServiceCollection AddMatrixMultiplicationAlgorithm(this IServiceCollection services)
    {
        services.AddTransient<
            ICancellableAlgorithm<MatrixMultiplicationOptions, MatrixMultiplicationResult>,
            MatrixMultiplicationAlgorithm>();

        services.AddTransient<
            IDataGenerator<MatrixMultiplicationDataGeneratorOptions, MatrixMultiplicationOptions>,
            MatrixMultiplicationDataGenerator>();

        services.AddTransient<
            ICancellableCoordinator<MatrixMultiplicationCoordinatorOptions>,
            MatrixMultiplicationCoordinator>();

        services.AddTransient<
            IMapper<DisplayableOptionInputs, MatrixMultiplicationCoordinatorOptions>,
            MatrixMultiplicationCoordinatorOptionsMapper>();

        services.AddTransient<
            IValidator<MatrixMultiplicationCoordinatorOptions>,
            MatrixMultiplicationCoordinatorOptionsValidator>();

        return services;
    }   
    
    public static IServiceCollection AddKadaneAlgorithm(this IServiceCollection services)
    {
        services.AddTransient<
            ICancellableAlgorithm<KadaneOptions, KadaneResult>,
            KadaneAlgorithm>();

        services.AddTransient<
            IDataGenerator<KadaneDataGeneratorOptions, KadaneOptions>,
            KadaneDataGenerator>();

        services.AddTransient<
            ICancellableCoordinator<KadaneCoordinatorOptions>,
            KadaneCoordinator>();

        services.AddTransient<
            IMapper<DisplayableOptionInputs, KadaneCoordinatorOptions>,
            KadaneCoordinatorOptionsMapper>();

        services.AddTransient<
            IValidator<KadaneCoordinatorOptions>,
            KadaneCoordinatorOptionsValidator>();

        return services;
    }
    
        
    public static IServiceCollection AddConstAlgorithm(this IServiceCollection services)
    {
        services.AddTransient<
            ICancellableAlgorithm<ConstOptions, ConstResult>,
            ConstAlgorithm>();

        services.AddTransient<
            IDataGenerator<ConstDataGeneratorOptions, ConstOptions>,
            ConstDataGenerator>();

        services.AddTransient<
            ICancellableCoordinator<ConstCoordinatorOptions>,
            ConstCoordinator>();

        services.AddTransient<
            IMapper<DisplayableOptionInputs, ConstCoordinatorOptions>,
            ConstCoordinatorOptionsMapper>();

        services.AddTransient<
            IValidator<ConstCoordinatorOptions>,
            ConstCoordinatorOptionsValidator>();

        return services;
    }
            
    public static IServiceCollection AddLISAlgorithm(this IServiceCollection services)
    {
        services.AddTransient<
            ICancellableAlgorithm<LISOptions, LISResult>,
            LISAlgorithm>();

        services.AddTransient<
            IDataGenerator<LISDataGeneratorOptions, LISOptions>,
            LISDataGenerator>();

        services.AddTransient<
            ICancellableCoordinator<LISCoordinatorOptions>,
            LISCoordinator>();

        services.AddTransient<
            IMapper<DisplayableOptionInputs, LISCoordinatorOptions>,
            LISCoordinatorOptionsMapper>();

        services.AddTransient<
            IValidator<LISCoordinatorOptions>,
            LISCoordinatorOptionsValidator>();

        return services;
    }
}
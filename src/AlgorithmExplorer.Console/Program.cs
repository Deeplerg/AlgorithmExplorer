using System.Reflection;
using System.Text;
using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Application.InputExecutors;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Application.Providers.InputExecutors;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.Benchmarking.Operations;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation.Results;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

Console.OutputEncoding = Encoding.Unicode;

string filename = "config.json";
string position = "displayableAlgorithmOptions";

var configBuilder = new ConfigurationBuilder();
configBuilder.AddJsonFile(filename);
var config = configBuilder.Build();

var services = new ServiceCollection();

services.AddAlgorithms();

services.AddTransient<ITimeAlgorithmRunner, TimeAlgorithmRunner>();
services.AddTransient<IOperationsAlgorithmRunner, OperationsAlgorithmRunner>();

services.AddSingleton<IInputExecutorTypeCollection, InputExecutorTypeCollection>(_ =>
{
    var typeCollection = new InputExecutorTypeCollection();
    typeCollection.AddAllFromAssembly(Assembly.GetAssembly(typeof(IInputExecutor<>))!);

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
Console.WriteLine();

var stepNames = Enum.GetNames<StepType>();
Console.WriteLine("Available step types:");
foreach (var name in stepNames)
{
    Console.WriteLine(name);
}
Console.WriteLine();

string reportProgressInput;
do
{
    Console.Write("Report progress? (Y/N) ");
    reportProgressInput = Console.ReadLine()!;
} while (reportProgressInput != "Y" && reportProgressInput != "N");

bool shouldReportProgress = reportProgressInput == "Y";

Console.Write("Algorithm: ");
string algorithmInput = Console.ReadLine()!;
bool isParsed = Enum.TryParse(typeof(AlgorithmType), algorithmInput, ignoreCase: true, out object? algorithmObject);

if (!isParsed || algorithmObject is null || (AlgorithmType)algorithmObject == AlgorithmType.None)
{
    Console.WriteLine("No such algorithm!");
    return;
}
var algorithm = (AlgorithmType)algorithmObject;


var displayableAlgorithmOption = options.Value.Algorithms.First(x => x.AlgorithmName == algorithm);
List<DisplayableOptionInput> inputOptions = new();
foreach (var dispayableOption in displayableAlgorithmOption.DisplayableCoordinatorOptions)
{
    Console.Write("\n" + dispayableOption.DisplayName + ": ");
    string input = Console.ReadLine()!;
    inputOptions.Add(new DisplayableOptionInput(dispayableOption, input));
}
var inputs = new DisplayableOptionInputs(displayableAlgorithmOption.AlgorithmName, inputOptions);


var executorProvider = provider.GetRequiredService<IInputExecutorProvider>();

bool isPowAlgorithm =
    algorithm is AlgorithmType.DefaultPow
              or AlgorithmType.QuickPow
              or AlgorithmType.RecursivePow
              or AlgorithmType.SimplePow;

ExecutorType executorType = isPowAlgorithm ? ExecutorType.Operations : ExecutorType.Time;

var executor = GetExecutor(executorType, executorProvider);

var validationResult = SetInputAndValidate(executor, executorType, inputs);

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

bool isPrepared = await PrepareDataAsync(executor, executorType, token);
Console.WriteLine($"Prepared: {isPrepared}");

if (!isPrepared)
{
    Console.WriteLine("Preparation cancelled!");
    return;
}

Progress<BenchmarkProgressReport> progress = null!;
if (shouldReportProgress)
{
    progress = new Progress<BenchmarkProgressReport>();
    progress.ProgressChanged += (sender, report) => Console.WriteLine($"Done: {report.RunsCompleted}");
}

switch (executorType)
{
    case ExecutorType.Time:
        var timeExecutor = (IInputExecutor<TimeBenchmarkResult>)executor;
        var timeResult = await timeExecutor.RunAsync(token, progress);
        Console.WriteLine($"Total Time: {timeResult.TotalTimeElapsed}, " +
                          $"Average Time: {TimeSpan.FromTicks((long)timeResult.AlgorithmResults.Average(x => x.TimeElapsed.Ticks))}");
        break;
    case ExecutorType.Operations:
        var operationsExecutor = (IInputExecutor<OperationsBenchmarkResult>)executor;
        var operationsResult = await operationsExecutor.RunAsync(token, progress);
        Console.WriteLine($"Total Operations: {operationsResult.TotalOperations}, " +
                          $"Average Operations: {(long)operationsResult.AlgorithmResults.Average(x => x.Operations)}");
        break;
    default:
        throw new ArgumentException($"Unknown {nameof(ExecutorType)}: {executorType}");
}

object GetExecutor(ExecutorType type, IInputExecutorProvider provider)
{
    switch (type)
    {
        case ExecutorType.Time:
            return provider.GetByAlgorithm<TimeBenchmarkResult>(algorithm)!;
        case ExecutorType.Operations:
            return provider.GetByAlgorithm<OperationsBenchmarkResult>(algorithm)!;
        default:
            throw new ArgumentException($"Unknown {nameof(ExecutorType)}: {type}");
    }
}

ValidationResult SetInputAndValidate(object executor, ExecutorType type, DisplayableOptionInputs inputs)
{
    switch (type)
    {
        case ExecutorType.Time:
            var timeExecutor = (IInputExecutor<TimeBenchmarkResult>)executor;
            timeExecutor.SetInput(inputs);
            return timeExecutor.ValidateInput();
        case ExecutorType.Operations:
            var operationsExecutor = (IInputExecutor<OperationsBenchmarkResult>)executor;
            operationsExecutor.SetInput(inputs);
            return operationsExecutor.ValidateInput();
        default:
            throw new ArgumentException($"Unknown {nameof(ExecutorType)}: {type}");
    }
}

async Task<bool> PrepareDataAsync(object executor, ExecutorType type, CancellationToken token)
{
    switch (type)
    {
        case ExecutorType.Time:
            var timeExecutor = (IInputExecutor<TimeBenchmarkResult>)executor;
            return await timeExecutor.PrepareDataAsync(token);
        case ExecutorType.Operations:
            var operationsExecutor = (IInputExecutor<OperationsBenchmarkResult>)executor;
            return await operationsExecutor.PrepareDataAsync(token);
        default:
            throw new ArgumentException($"Unknown {nameof(ExecutorType)}: {type}");
    }
}

enum ExecutorType
{
    Time,
    Operations
}
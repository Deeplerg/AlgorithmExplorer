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
var executor = executorProvider.GetByAlgorithm<TimeBenchmarkResult>(algorithm)!;

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

Progress<BenchmarkProgressReport> progress = null!;
if (shouldReportProgress)
{
    progress = new Progress<BenchmarkProgressReport>();
    progress.ProgressChanged += (sender, report) => Console.WriteLine($"Done: {report.RunsCompleted}");
}

var benchmarkResult = await executor.RunAsync(token, progress);
Console.WriteLine($"Total Time: {benchmarkResult.TotalTimeElapsed}, " +
                  $"Average Time: {TimeSpan.FromTicks((long)benchmarkResult.AlgorithmResults.Average(x => x.TimeElapsed.Ticks))}");
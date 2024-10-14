using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.Benchmarking.Operations;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.Base;

public abstract class PowCoordinatorBase<
    TCoordinatorOptions,
    TRunOptions,
    TResult,
    TDataGeneratorOptions>
    : CoordinatorBase<
        TCoordinatorOptions, TRunOptions, TResult, TDataGeneratorOptions, OperationsBenchmarkResult>
    where TRunOptions : class
    where TCoordinatorOptions : PowCoordinatorOptionsBase
    where TDataGeneratorOptions : PowDataGeneratorOptionsBase
    where TResult : OperationsResultBase
{
    private readonly IOperationsAlgorithmRunner _runner;

    protected PowCoordinatorBase(
        IDataGenerator<TDataGeneratorOptions, TRunOptions> generator,
        ICancellableAlgorithm<TRunOptions, TResult> algorithm,
        IOperationsAlgorithmRunner runner)
        : base(generator, algorithm)
    {
        _runner = runner;
    }

    public override async Task<OperationsBenchmarkResult> RunAsync(
        CancellationToken token, IProgress<BenchmarkProgressReport>? progress = null)
    {
        GuardAgainstNoData();
        
        var runnerOptions = new OperationsRunnerOptions<
            ICancellableAlgorithm<TRunOptions, TResult>, TRunOptions, TResult>(
            _algorithm, _data!, _totalDataCount);
        
        var runResult = await _runner.RunAsync(
            runnerOptions, token, progress);

        return runResult;
    }

    protected TDataGeneratorOptions ConstructInheritedGeneratorOptions(
        TDataGeneratorOptions emptyInheritedOptions,
        TCoordinatorOptions coordinatorOptions,
        int currentIteration)
    {
        var @base = ConstructBaseGeneratorOptions(coordinatorOptions, currentIteration);

        var castOptions = (PowDataGeneratorOptionsBase)emptyInheritedOptions;
        castOptions.Power = @base.Power;
        castOptions.Base = @base.Base;

        return (TDataGeneratorOptions)castOptions;
    }

    protected PowDataGeneratorOptionsBase ConstructBaseGeneratorOptions(
        TCoordinatorOptions options, int currentIteration)
        => new(currentIteration, options.Number);
}
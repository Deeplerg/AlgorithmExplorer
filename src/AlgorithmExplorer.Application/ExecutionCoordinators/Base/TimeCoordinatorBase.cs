using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Core.DataGenerators;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.Base;

public abstract class TimeCoordinatorBase<
    TCoordinatorOptions,
    TRunOptions,
    TResult,
    TDataGeneratorOptions> 
    : CoordinatorBase<
        TCoordinatorOptions, TRunOptions, TResult, TDataGeneratorOptions, TimeBenchmarkResult>
    where TRunOptions : class
    where TCoordinatorOptions : CoordinatorOptionsBase
{
    private readonly ITimeAlgorithmRunner _runner;

    protected TimeCoordinatorBase(
        IDataGenerator<TDataGeneratorOptions, TRunOptions> generator, 
        ICancellableAlgorithm<TRunOptions, TResult> algorithm, 
        ITimeAlgorithmRunner runner) : base(generator, algorithm)
    {
        _runner = runner;
    }
    
    public override async Task<TimeBenchmarkResult> RunAsync(
        CancellationToken token,
        IProgress<BenchmarkProgressReport>? progress = null)
    {
        GuardAgainstNoData();

        var runnerOptions = new TimeRunnerOptions<
            ICancellableAlgorithm<TRunOptions, TResult>, TRunOptions, TResult>(
            _algorithm, _data);
        
        var runResult = await _runner.RunAsync(
            runnerOptions, token, progress);

        return runResult;
    }
}
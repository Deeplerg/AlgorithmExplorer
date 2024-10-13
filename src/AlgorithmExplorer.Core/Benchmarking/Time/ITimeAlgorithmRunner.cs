using AlgorithmExplorer.Core.Algorithms;

namespace AlgorithmExplorer.Core.Benchmarking.Time;

public interface ITimeAlgorithmRunner
{
    Task<TimeBenchmarkResult> RunAsync<TAlgorithm, TRunOptions, TResult>(
        TimeRunnerOptions<TAlgorithm, TRunOptions, TResult> options,
        CancellationToken cancellationToken,
        IProgress<BenchmarkProgressReport>? progress = null)
        where TAlgorithm : ICancellableAlgorithm<TRunOptions, TResult>
        where TRunOptions : class;
}
using AlgorithmExplorer.Core.Algorithms;

namespace AlgorithmExplorer.Core.Benchmarking.Operations;

public interface IOperationsAlgorithmRunner
{
    Task<OperationsBenchmarkResult> RunAsync<TAlgorithm, TRunOptions, TResult>(
        OperationsRunnerOptions<TAlgorithm, TRunOptions, TResult> options,
        CancellationToken cancellationToken,
        IProgress<BenchmarkProgressReport>? progress = null)
        where TAlgorithm : ICancellableAlgorithm<TRunOptions, TResult>
        where TRunOptions : class
        where TResult : OperationsResultBase;
}
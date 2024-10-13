using AlgorithmExplorer.Core.Algorithms;

namespace AlgorithmExplorer.Core.Benchmarking;

public interface ICancellableAlgorithmRunner
{
    Task<BenchmarkResult> RunAsync<TAlgorithm, TRunOptions, TResult>(
        TAlgorithm algorithm, 
        IEnumerable<NumberedRunOptions<TRunOptions>> options,
        CancellationToken cancellationToken,
        IProgress<BenchmarkProgressReport>? progress = null)
        where TAlgorithm : ICancellableAlgorithm<TRunOptions, TResult>
        where TRunOptions : class;
}
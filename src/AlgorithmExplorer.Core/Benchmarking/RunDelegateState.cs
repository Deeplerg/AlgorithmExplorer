using AlgorithmExplorer.Core.Algorithms;

namespace AlgorithmExplorer.Core.Benchmarking;

public class RunDelegateState<TAlgorithm, TRunOptions, TResult>(
    TAlgorithm algorithm,
    CancellationToken cancellationToken,
    TRunOptions? runOptions = null)
    where TAlgorithm : ICancellableAlgorithm<TRunOptions, TResult>
    where TRunOptions : class
{
    public TAlgorithm Algorithm { get; set; } = algorithm;
    public CancellationToken CancellationToken { get; set; } = cancellationToken;
    public TRunOptions? RunOptions { get; set; } = runOptions;
}
namespace AlgorithmExplorer.Core.Algorithms;

public interface ICancellableAlgorithm<TRunOptions, TResult>
    where TRunOptions : class
{
    CancellableResult<TResult> Run(TRunOptions options, CancellationToken token);
}
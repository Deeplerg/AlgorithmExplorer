using AlgorithmExplorer.Core.Algorithms;

namespace AlgorithmExplorer.Core.Benchmarking.Operations;

public record class OperationsRunnerOptions<TAlgorithm, TRunOptions, TResult>(
    TAlgorithm Algorithm, 
    IEnumerable<NumberedRunOptions<TRunOptions>> RunOptions)
    where TAlgorithm : ICancellableAlgorithm<TRunOptions, TResult>
    where TRunOptions : class
    where TResult : OperationsResultBase;
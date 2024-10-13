using AlgorithmExplorer.Core.Algorithms;

namespace AlgorithmExplorer.Core.Benchmarking.Time;

public record class TimeRunnerOptions<TAlgorithm, TRunOptions, TResult>(
    TAlgorithm Algorithm, 
    IEnumerable<NumberedRunOptions<TRunOptions>> RunOptions)
    where TAlgorithm : ICancellableAlgorithm<TRunOptions, TResult>
    where TRunOptions : class;
using AlgorithmExplorer.Core.Algorithms;

namespace AlgorithmExplorer.Core.Benchmarking.Time;

public record class TimeRunnerOptions<TAlgorithm, TRunOptions, TResult>(
    TAlgorithm Algorithm, 
    IAsyncEnumerable<NumberedRunOptions<TRunOptions>> RunOptions,
    int TotalOptionsCount)
    where TAlgorithm : ICancellableAlgorithm<TRunOptions, TResult>
    where TRunOptions : class;
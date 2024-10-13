namespace AlgorithmExplorer.Core.Benchmarking;

public record class NumberedRunOptions<TRunOptions>(
    TRunOptions RunOptions, 
    int DataLength)
    where TRunOptions : class;
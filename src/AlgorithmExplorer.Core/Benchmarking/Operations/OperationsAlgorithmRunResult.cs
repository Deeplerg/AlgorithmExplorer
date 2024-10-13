namespace AlgorithmExplorer.Core.Benchmarking.Operations;

public record class OperationsAlgorithmRunResult(
    long Operations,
    bool IsCancelled,
    int DataLength);
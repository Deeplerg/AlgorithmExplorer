namespace AlgorithmExplorer.Core.Benchmarking.Operations;

public record class OperationsBenchmarkResult(
    IEnumerable<OperationsAlgorithmRunResult> AlgorithmResults,
    bool IsCancelled,
    long TotalOperations);
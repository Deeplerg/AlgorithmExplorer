namespace AlgorithmExplorer.Core.Benchmarking;

public record class BenchmarkResult(
    IEnumerable<AlgorithmRunResult> AlgorithmResults,
    bool IsCancelled,
    TimeSpan TotalTimeElapsed);
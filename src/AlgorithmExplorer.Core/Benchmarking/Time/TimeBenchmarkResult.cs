namespace AlgorithmExplorer.Core.Benchmarking.Time;

public record class TimeBenchmarkResult(
    IEnumerable<TimeAlgorithmRunResult> AlgorithmResults,
    bool IsCancelled,
    TimeSpan TotalTimeElapsed);
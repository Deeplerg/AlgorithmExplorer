namespace AlgorithmExplorer.Core.Benchmarking.Time;

public record class TimeAlgorithmRunResult(
    TimeSpan TimeElapsed,
    bool IsCancelled,
    int DataLength);
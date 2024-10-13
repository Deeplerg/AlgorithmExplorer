using AlgorithmExplorer.Core.Algorithms;

namespace AlgorithmExplorer.Core.Benchmarking;

public record class AlgorithmRunResult(
    TimeSpan TimeElapsed,
    bool IsCancelled,
    int DataLength);
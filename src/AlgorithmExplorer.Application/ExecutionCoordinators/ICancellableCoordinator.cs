using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.Benchmarking.Time;

namespace AlgorithmExplorer.Application.ExecutionCoordinators;

public interface ICancellableCoordinator<TCoordinatorOptions>
{
    Task<bool> PrepareDataAsync(TCoordinatorOptions options, CancellationToken token);
    Task<TimeBenchmarkResult> RunAsync(
        CancellationToken token, 
        IProgress<BenchmarkProgressReport>? progress = null);
}
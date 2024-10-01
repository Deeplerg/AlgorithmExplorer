using AlgorithmExplorer.Core.Benchmarking;

namespace AlgorithmExplorer.Application.ExecutionCoordinators;

public interface ICancellableCoordinator<TCoordinatorOptions>
{
    Task<bool> PrepareDataAsync(TCoordinatorOptions options, CancellationToken token);
    Task<BenchmarkResult> RunAsync(
        CancellationToken token, 
        IProgress<BenchmarkProgressReport>? progress = null);
}
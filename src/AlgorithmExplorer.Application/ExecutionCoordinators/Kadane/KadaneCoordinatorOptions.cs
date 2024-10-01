using AlgorithmExplorer.Application.ExecutionCoordinators.Base;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.Kadane;

public record class KadaneCoordinatorOptions(
    int IterationCount) : CoordinatorOptionsBase(IterationCount);
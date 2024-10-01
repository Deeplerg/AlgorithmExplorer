using AlgorithmExplorer.Application.ExecutionCoordinators.Base;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.LIS;

public record class LISCoordinatorOptions(
    int IterationCount) : CoordinatorOptionsBase(IterationCount);
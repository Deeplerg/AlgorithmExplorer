using AlgorithmExplorer.Application.ExecutionCoordinators.Base;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.Sum;

public record class SumCoordinatorOptions(
    int IterationCount) : CoordinatorOptionsBase(IterationCount);
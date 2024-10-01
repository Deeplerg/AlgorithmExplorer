using AlgorithmExplorer.Application.ExecutionCoordinators.Base;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.Gorner;

public record class GornerCoordinatorOptions(
    int IterationCount) : CoordinatorOptionsBase(IterationCount);
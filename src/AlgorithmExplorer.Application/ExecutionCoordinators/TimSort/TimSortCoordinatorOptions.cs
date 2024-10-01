using AlgorithmExplorer.Application.ExecutionCoordinators.Base;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.TimSort;

public record class TimSortCoordinatorOptions(
    int IterationCount) : CoordinatorOptionsBase(IterationCount);
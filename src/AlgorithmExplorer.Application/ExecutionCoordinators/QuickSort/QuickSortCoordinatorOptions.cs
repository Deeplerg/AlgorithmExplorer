using AlgorithmExplorer.Application.ExecutionCoordinators.Base;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.QuickSort;

public record class QuickSortCoordinatorOptions(
    int IterationCount) : CoordinatorOptionsBase(IterationCount);
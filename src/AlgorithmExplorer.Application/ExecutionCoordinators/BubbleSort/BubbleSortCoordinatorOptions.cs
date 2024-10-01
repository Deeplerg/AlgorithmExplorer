using AlgorithmExplorer.Application.ExecutionCoordinators.Base;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.BubbleSort;

public record class BubbleSortCoordinatorOptions(
    int IterationCount) : CoordinatorOptionsBase(IterationCount);
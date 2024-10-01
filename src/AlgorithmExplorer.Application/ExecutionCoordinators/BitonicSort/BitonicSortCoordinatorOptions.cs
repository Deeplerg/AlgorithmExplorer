using AlgorithmExplorer.Application.ExecutionCoordinators.Base;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.BitonicSort;

public record class BitonicSortCoordinatorOptions(
    int IterationCount) : CoordinatorOptionsBase(IterationCount);
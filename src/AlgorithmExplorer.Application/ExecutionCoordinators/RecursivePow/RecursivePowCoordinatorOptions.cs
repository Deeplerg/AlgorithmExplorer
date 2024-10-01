using AlgorithmExplorer.Application.ExecutionCoordinators.Base;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.RecursivePow;

public record class RecursivePowCoordinatorOptions(
    int IterationCount, int Number) : CoordinatorOptionsBase(IterationCount);
using AlgorithmExplorer.Application.ExecutionCoordinators.Base;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.SimplePow;

public record class SimplePowCoordinatorOptions(
    int IterationCount, int Number) : CoordinatorOptionsBase(IterationCount);
using AlgorithmExplorer.Application.ExecutionCoordinators.Base;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.DefaultPow;

public record class DefaultPowCoordinatorOptions(
    int IterationCount, int Number) : CoordinatorOptionsBase(IterationCount);
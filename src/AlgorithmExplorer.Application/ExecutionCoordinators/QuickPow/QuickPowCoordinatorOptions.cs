using AlgorithmExplorer.Application.ExecutionCoordinators.Base;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.QuickPow;

public record class QuickPowCoordinatorOptions(
    int IterationCount, int Number) : CoordinatorOptionsBase(IterationCount);
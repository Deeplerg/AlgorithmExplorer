using AlgorithmExplorer.Application.ExecutionCoordinators.Base;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.Const;

public record class ConstCoordinatorOptions(
    int IterationCount) : CoordinatorOptionsBase(IterationCount);
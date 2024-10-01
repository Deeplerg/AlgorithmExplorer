using AlgorithmExplorer.Application.ExecutionCoordinators.Base;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.Multiplication;

public record class MultiplicationCoordinatorOptions(
    int IterationCount) : CoordinatorOptionsBase(IterationCount);
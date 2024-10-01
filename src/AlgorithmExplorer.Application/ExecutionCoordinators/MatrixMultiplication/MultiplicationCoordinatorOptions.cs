using AlgorithmExplorer.Application.ExecutionCoordinators.Base;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.MatrixMultiplication;

public record class MatrixMultiplicationCoordinatorOptions(
    int IterationCount) : CoordinatorOptionsBase(IterationCount);
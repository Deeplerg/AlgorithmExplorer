using AlgorithmExplorer.Application.ExecutionCoordinators.Base;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.Polynom;

public record class PolynomCoordinatorOptions(
    int IterationCount) : CoordinatorOptionsBase(IterationCount);
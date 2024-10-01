using AlgorithmExplorer.Application.ExecutionCoordinators.MatrixMultiplication;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;

public class MatrixMultiplicationCoordinatorOptionsValidator : AbstractValidator<MatrixMultiplicationCoordinatorOptions>
{
    public MatrixMultiplicationCoordinatorOptionsValidator()
    {
        RuleFor(x => x.IterationCount).GreaterThan(0);
    }
}
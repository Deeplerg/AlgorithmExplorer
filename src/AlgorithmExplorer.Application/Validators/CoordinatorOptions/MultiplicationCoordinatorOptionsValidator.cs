using AlgorithmExplorer.Application.ExecutionCoordinators.Multiplication;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;

public class MultiplicationCoordinatorOptionsValidator : AbstractValidator<MultiplicationCoordinatorOptions>
{
    public MultiplicationCoordinatorOptionsValidator()
    {
        RuleFor(x => x.IterationCount).GreaterThan(0);
    }
}
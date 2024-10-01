using AlgorithmExplorer.Application.ExecutionCoordinators.Sum;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;

public class SumCoordinatorOptionsValidator : AbstractValidator<SumCoordinatorOptions>
{
    public SumCoordinatorOptionsValidator()
    {
        RuleFor(x => x.IterationCount).GreaterThan(0);
    }
}
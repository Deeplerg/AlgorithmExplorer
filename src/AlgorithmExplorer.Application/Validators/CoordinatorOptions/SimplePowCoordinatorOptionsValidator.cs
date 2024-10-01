using AlgorithmExplorer.Application.ExecutionCoordinators.SimplePow;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;

public class SimplePowCoordinatorOptionsValidator : AbstractValidator<SimplePowCoordinatorOptions>
{
    public SimplePowCoordinatorOptionsValidator()
    {
        RuleFor(x => x.IterationCount).GreaterThan(0);
        RuleFor(x => x.Number).GreaterThan(0);
    }
}
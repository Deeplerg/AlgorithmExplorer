using AlgorithmExplorer.Application.ExecutionCoordinators.QuickPow;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;

public class QuickPowCoordinatorOptionsValidator : AbstractValidator<QuickPowCoordinatorOptions>
{
    public QuickPowCoordinatorOptionsValidator()
    {
        RuleFor(x => x.IterationCount).GreaterThan(0);
        RuleFor(x => x.Number).GreaterThan(0);
    }
}
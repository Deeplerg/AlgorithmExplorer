using AlgorithmExplorer.Application.ExecutionCoordinators.DefaultPow;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;
public class DefaultPowCoordinatorOptionsValidator : AbstractValidator<DefaultPowCoordinatorOptions>
{
    public DefaultPowCoordinatorOptionsValidator()
    {
        RuleFor(x => x.IterationCount).GreaterThan(0);
        RuleFor(x => x.Number).GreaterThan(0);
    }
}
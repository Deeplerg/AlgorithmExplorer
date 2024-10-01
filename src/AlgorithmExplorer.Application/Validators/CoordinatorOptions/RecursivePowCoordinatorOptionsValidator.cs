using AlgorithmExplorer.Application.ExecutionCoordinators.RecursivePow;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;

public class RecursivePowCoordinatorOptionsValidator : AbstractValidator<RecursivePowCoordinatorOptions>
{
    public RecursivePowCoordinatorOptionsValidator()
    {
        RuleFor(x => x.IterationCount).GreaterThan(0);
        RuleFor(x => x.Number).GreaterThan(0);
    }
}
using AlgorithmExplorer.Application.ExecutionCoordinators.Gorner;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;

public class GornerCoordinatorOptionsValidator : AbstractValidator<GornerCoordinatorOptions>
{
    public GornerCoordinatorOptionsValidator()
    {
        RuleFor(x => x.IterationCount).GreaterThan(0);
    }
}
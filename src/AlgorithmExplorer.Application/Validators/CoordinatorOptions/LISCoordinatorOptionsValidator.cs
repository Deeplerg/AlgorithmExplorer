using AlgorithmExplorer.Application.ExecutionCoordinators.LIS;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;

public class LISCoordinatorOptionsValidator : AbstractValidator<LISCoordinatorOptions>
{
    public LISCoordinatorOptionsValidator()
    {
        RuleFor(x => x.IterationCount).GreaterThan(0);
    }
}
using AlgorithmExplorer.Application.ExecutionCoordinators.Kadane;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;

public class KadaneCoordinatorOptionsValidator : AbstractValidator<KadaneCoordinatorOptions>
{
    public KadaneCoordinatorOptionsValidator()
    {
        RuleFor(x => x.IterationCount).GreaterThan(0);
    }
}
using AlgorithmExplorer.Application.ExecutionCoordinators.TimSort;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;

public class TimSortCoordinatorOptionsValidator : AbstractValidator<TimSortCoordinatorOptions>
{
    public TimSortCoordinatorOptionsValidator()
    {
        RuleFor(x => x.IterationCount).GreaterThan(0);
    }
}
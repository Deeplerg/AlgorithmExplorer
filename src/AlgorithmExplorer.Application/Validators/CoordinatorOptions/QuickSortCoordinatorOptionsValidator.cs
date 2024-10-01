using AlgorithmExplorer.Application.ExecutionCoordinators.QuickSort;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;

public class QuickSortCoordinatorOptionsValidator : AbstractValidator<QuickSortCoordinatorOptions>
{
    public QuickSortCoordinatorOptionsValidator()
    {
        RuleFor(x => x.IterationCount).GreaterThan(0);
    }
}
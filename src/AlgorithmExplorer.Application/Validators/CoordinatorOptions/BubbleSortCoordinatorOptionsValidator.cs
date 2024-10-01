using AlgorithmExplorer.Application.ExecutionCoordinators.BubbleSort;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;

public class BubbleSortCoordinatorOptionsValidator : AbstractValidator<BubbleSortCoordinatorOptions>
{
    public BubbleSortCoordinatorOptionsValidator()
    {
        RuleFor(x => x.IterationCount).GreaterThan(0);
    }
}
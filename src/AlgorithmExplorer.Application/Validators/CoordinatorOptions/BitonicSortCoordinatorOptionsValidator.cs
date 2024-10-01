using AlgorithmExplorer.Application.ExecutionCoordinators.BitonicSort;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;

public class BitonicSortCoordinatorOptionsValidator : AbstractValidator<BitonicSortCoordinatorOptions>
{
    public BitonicSortCoordinatorOptionsValidator()
    {
        RuleFor(x => x.IterationCount).GreaterThan(0);
    }
}
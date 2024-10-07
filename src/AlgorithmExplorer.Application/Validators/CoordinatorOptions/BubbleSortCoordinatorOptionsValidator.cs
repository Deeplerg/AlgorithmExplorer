using AlgorithmExplorer.Application.ExecutionCoordinators.BubbleSort;
using AlgorithmExplorer.Application.Validators.CoordinatorOptions.Base;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;

public class BubbleSortCoordinatorOptionsValidator 
    : CoordinatorOptionsBaseValidator<BubbleSortCoordinatorOptions>
{
}
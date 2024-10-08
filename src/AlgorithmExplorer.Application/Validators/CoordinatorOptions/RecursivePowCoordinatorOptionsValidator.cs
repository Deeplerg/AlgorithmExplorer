using AlgorithmExplorer.Application.ExecutionCoordinators.RecursivePow;
using AlgorithmExplorer.Application.Validators.CoordinatorOptions.Base;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;

public class RecursivePowCoordinatorOptionsValidator 
    : PowCoordinatorOptionsBaseValidator<RecursivePowCoordinatorOptions>
{
}
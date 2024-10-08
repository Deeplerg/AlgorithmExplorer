using AlgorithmExplorer.Application.ExecutionCoordinators.SimplePow;
using AlgorithmExplorer.Application.Validators.CoordinatorOptions.Base;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;

public class SimplePowCoordinatorOptionsValidator 
    : PowCoordinatorOptionsBaseValidator<SimplePowCoordinatorOptions>
{
}
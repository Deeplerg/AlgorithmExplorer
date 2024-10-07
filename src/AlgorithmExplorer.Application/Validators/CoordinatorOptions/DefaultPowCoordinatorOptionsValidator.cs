using AlgorithmExplorer.Application.ExecutionCoordinators.DefaultPow;
using AlgorithmExplorer.Application.Validators.CoordinatorOptions.Base;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;
public class DefaultPowCoordinatorOptionsValidator 
    : PowCoordinatorOptionsBaseValidator<DefaultPowCoordinatorOptions>
{
}
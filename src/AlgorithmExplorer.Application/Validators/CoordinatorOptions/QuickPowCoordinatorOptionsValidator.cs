using AlgorithmExplorer.Application.ExecutionCoordinators.QuickPow;
using AlgorithmExplorer.Application.Validators.CoordinatorOptions.Base;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;

public class QuickPowCoordinatorOptionsValidator 
    : PowCoordinatorOptionsBaseValidator<QuickPowCoordinatorOptions>
{
}
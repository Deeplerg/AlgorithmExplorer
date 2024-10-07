using AlgorithmExplorer.Application.ExecutionCoordinators.Const;
using AlgorithmExplorer.Application.Validators.CoordinatorOptions.Base;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;

public class ConstCoordinatorOptionsValidator 
    : CoordinatorOptionsBaseValidator<ConstCoordinatorOptions>
{
}
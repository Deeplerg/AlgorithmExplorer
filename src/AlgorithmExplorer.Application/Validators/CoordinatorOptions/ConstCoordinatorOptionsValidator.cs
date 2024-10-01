using AlgorithmExplorer.Application.ExecutionCoordinators.Const;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;

public class ConstCoordinatorOptionsValidator : AbstractValidator<ConstCoordinatorOptions>
{
    public ConstCoordinatorOptionsValidator()
    {
        RuleFor(x => x.IterationCount).GreaterThan(0);
    }
}
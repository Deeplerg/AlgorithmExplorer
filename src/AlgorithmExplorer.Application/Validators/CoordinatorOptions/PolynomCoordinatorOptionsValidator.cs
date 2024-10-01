using AlgorithmExplorer.Application.ExecutionCoordinators.Polynom;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions;

public class PolynomCoordinatorOptionsValidator : AbstractValidator<PolynomCoordinatorOptions>
{
    public PolynomCoordinatorOptionsValidator()
    {
        RuleFor(x => x.IterationCount).GreaterThan(0);
    }
}
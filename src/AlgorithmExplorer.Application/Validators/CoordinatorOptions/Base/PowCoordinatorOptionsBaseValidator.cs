using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions.Base;

public class PowCoordinatorOptionsBaseValidator<T> : CoordinatorOptionsBaseValidator<T>
    where T : PowCoordinatorOptionsBase
{
    public PowCoordinatorOptionsBaseValidator()
    {
        RuleFor(x => x.Number).GreaterThan(0).WithMessage("Основание степени должно быть больше 0");
    }
}
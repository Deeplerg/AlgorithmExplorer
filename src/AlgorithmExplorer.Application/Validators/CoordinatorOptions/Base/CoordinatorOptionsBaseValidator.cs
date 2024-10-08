using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using FluentValidation;

namespace AlgorithmExplorer.Application.Validators.CoordinatorOptions.Base;

public class CoordinatorOptionsBaseValidator<T> : AbstractValidator<T>
    where T : CoordinatorOptionsBase
{
    public CoordinatorOptionsBaseValidator()
    {
        RuleFor(x => x.IterationCount).GreaterThan(0).WithMessage("Длина вектора должна быть больше 0");
        RuleFor(x => x.Step).GreaterThan(0).WithMessage("Шаг должен быть больше 0");
    }
}
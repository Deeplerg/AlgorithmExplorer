using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.Polynom;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation;

namespace AlgorithmExplorer.Application.InputExecutors;

[ForAlgorithm(AlgorithmType.Polynom)]
public class PolynomInputExecutor : InputExecutorBase<PolynomCoordinatorOptions>
{
    public PolynomInputExecutor(
        IMapper<DisplayableOptionInputs, PolynomCoordinatorOptions> inputMapper, 
        IValidator<PolynomCoordinatorOptions> validator, 
        ICancellableCoordinator<PolynomCoordinatorOptions> coordinator) 
        : base(inputMapper, validator, coordinator)
    {
    }
}
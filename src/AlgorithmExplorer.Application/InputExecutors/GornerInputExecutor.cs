using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.Gorner;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation;

namespace AlgorithmExplorer.Application.InputExecutors;

[ForAlgorithm(AlgorithmType.Gorner)]
public class GornerInputExecutor : InputExecutorBase<GornerCoordinatorOptions>
{
    public GornerInputExecutor(
        IMapper<DisplayableOptionInputs, GornerCoordinatorOptions> inputMapper, 
        IValidator<GornerCoordinatorOptions> validator, 
        ICancellableCoordinator<GornerCoordinatorOptions> coordinator) 
        : base(inputMapper, validator, coordinator)
    {
    }
}
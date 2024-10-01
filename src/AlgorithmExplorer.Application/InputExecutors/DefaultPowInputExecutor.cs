using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.DefaultPow;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation;

namespace AlgorithmExplorer.Application.InputExecutors;

[ForAlgorithm(AlgorithmType.DefaultPow)]
public class DefaultPowInputExecutor : InputExecutorBase<DefaultPowCoordinatorOptions>
{
    public DefaultPowInputExecutor(
        IMapper<DisplayableOptionInputs, DefaultPowCoordinatorOptions> inputMapper, 
        IValidator<DefaultPowCoordinatorOptions> validator, 
        ICancellableCoordinator<DefaultPowCoordinatorOptions> coordinator) 
        : base(inputMapper, validator, coordinator)
    {
    }
}
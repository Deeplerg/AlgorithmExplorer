using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.SimplePow;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation;

namespace AlgorithmExplorer.Application.InputExecutors;

[ForAlgorithm(AlgorithmType.SimplePow)]
public class SimplePowInputExecutor : InputExecutorBase<SimplePowCoordinatorOptions>
{
    public SimplePowInputExecutor(
        IMapper<DisplayableOptionInputs, SimplePowCoordinatorOptions> inputMapper, 
        IValidator<SimplePowCoordinatorOptions> validator, 
        ICancellableCoordinator<SimplePowCoordinatorOptions> coordinator) 
        : base(inputMapper, validator, coordinator)
    {
    }
}
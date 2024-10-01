using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.RecursivePow;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation;

namespace AlgorithmExplorer.Application.InputExecutors;

[ForAlgorithm(AlgorithmType.RecursivePow)]
public class RecursivePowInputExecutor : InputExecutorBase<RecursivePowCoordinatorOptions>
{
    public RecursivePowInputExecutor(
        IMapper<DisplayableOptionInputs, RecursivePowCoordinatorOptions> inputMapper, 
        IValidator<RecursivePowCoordinatorOptions> validator, 
        ICancellableCoordinator<RecursivePowCoordinatorOptions> coordinator) 
        : base(inputMapper, validator, coordinator)
    {
    }
}
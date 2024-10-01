using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.QuickPow;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation;

namespace AlgorithmExplorer.Application.InputExecutors;

[ForAlgorithm(AlgorithmType.QuickPow)]
public class QuickPowInputExecutor : InputExecutorBase<QuickPowCoordinatorOptions>
{
    public QuickPowInputExecutor(
        IMapper<DisplayableOptionInputs, QuickPowCoordinatorOptions> inputMapper, 
        IValidator<QuickPowCoordinatorOptions> validator, 
        ICancellableCoordinator<QuickPowCoordinatorOptions> coordinator) 
        : base(inputMapper, validator, coordinator)
    {
    }
}
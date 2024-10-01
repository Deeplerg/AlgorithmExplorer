using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.LIS;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation;

namespace AlgorithmExplorer.Application.InputExecutors;

[ForAlgorithm(AlgorithmType.LIS)]
public class LISInputExecutor : InputExecutorBase<LISCoordinatorOptions>
{
    public LISInputExecutor(
        IMapper<DisplayableOptionInputs, LISCoordinatorOptions> inputMapper, 
        IValidator<LISCoordinatorOptions> validator, 
        ICancellableCoordinator<LISCoordinatorOptions> coordinator) 
        : base(inputMapper, validator, coordinator)
    {
    }
}
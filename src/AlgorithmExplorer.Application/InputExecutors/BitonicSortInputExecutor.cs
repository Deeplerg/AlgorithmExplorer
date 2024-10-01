using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.BitonicSort;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation;

namespace AlgorithmExplorer.Application.InputExecutors;

[ForAlgorithm(AlgorithmType.BitonicSort)]
public class BitonicSortInputExecutor : InputExecutorBase<BitonicSortCoordinatorOptions>
{
    public BitonicSortInputExecutor(
        IMapper<DisplayableOptionInputs, BitonicSortCoordinatorOptions> inputMapper, 
        IValidator<BitonicSortCoordinatorOptions> validator, 
        ICancellableCoordinator<BitonicSortCoordinatorOptions> coordinator) 
        : base(inputMapper, validator, coordinator)
    {
    }
}
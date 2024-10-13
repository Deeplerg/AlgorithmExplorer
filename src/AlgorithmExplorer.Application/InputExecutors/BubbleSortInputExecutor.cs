using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.BubbleSort;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation;

namespace AlgorithmExplorer.Application.InputExecutors;

[ForAlgorithm(AlgorithmType.BubbleSort)]
public class BubbleSortInputExecutor : InputExecutorBase<BubbleSortCoordinatorOptions, TimeBenchmarkResult>
{
    public BubbleSortInputExecutor(
        IMapper<DisplayableOptionInputs, BubbleSortCoordinatorOptions> inputMapper, 
        IValidator<BubbleSortCoordinatorOptions> validator, 
        ICancellableCoordinator<BubbleSortCoordinatorOptions, TimeBenchmarkResult> coordinator) 
        : base(inputMapper, validator, coordinator)
    {
    }
}
using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.QuickSort;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation;

namespace AlgorithmExplorer.Application.InputExecutors;

[ForAlgorithm(AlgorithmType.QuickSort)]
public class QuickSortInputExecutor : InputExecutorBase<QuickSortCoordinatorOptions, TimeBenchmarkResult>
{
    public QuickSortInputExecutor(
        IMapper<DisplayableOptionInputs, QuickSortCoordinatorOptions> inputMapper, 
        IValidator<QuickSortCoordinatorOptions> validator, 
        ICancellableCoordinator<QuickSortCoordinatorOptions, TimeBenchmarkResult> coordinator) 
        : base(inputMapper, validator, coordinator)
    {
    }
}
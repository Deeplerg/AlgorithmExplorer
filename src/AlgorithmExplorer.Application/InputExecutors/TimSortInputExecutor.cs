using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.TimSort;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation;

namespace AlgorithmExplorer.Application.InputExecutors;

[ForAlgorithm(AlgorithmType.TimSort)]
public class TimSortInputExecutor : InputExecutorBase<TimSortCoordinatorOptions, TimeBenchmarkResult>
{
    public TimSortInputExecutor(
        IMapper<DisplayableOptionInputs, TimSortCoordinatorOptions> inputMapper, 
        IValidator<TimSortCoordinatorOptions> validator, 
        ICancellableCoordinator<TimSortCoordinatorOptions, TimeBenchmarkResult> coordinator) 
        : base(inputMapper, validator, coordinator)
    {
    }
}
using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.Kadane;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation;

namespace AlgorithmExplorer.Application.InputExecutors;

[ForAlgorithm(AlgorithmType.Kadane)]
public class KadaneInputExecutor : InputExecutorBase<KadaneCoordinatorOptions, TimeBenchmarkResult>
{
    public KadaneInputExecutor(
        IMapper<DisplayableOptionInputs, KadaneCoordinatorOptions> inputMapper, 
        IValidator<KadaneCoordinatorOptions> validator, 
        ICancellableCoordinator<KadaneCoordinatorOptions, TimeBenchmarkResult> coordinator) 
        : base(inputMapper, validator, coordinator)
    {
    }
}
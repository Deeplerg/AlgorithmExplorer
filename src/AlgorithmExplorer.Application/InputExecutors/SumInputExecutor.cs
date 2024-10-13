using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.Sum;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation;

namespace AlgorithmExplorer.Application.InputExecutors;

[ForAlgorithm(AlgorithmType.Sum)]
public class SumInputExecutor : InputExecutorBase<SumCoordinatorOptions, TimeBenchmarkResult>
{
    public SumInputExecutor(
        IMapper<DisplayableOptionInputs, SumCoordinatorOptions> inputMapper, 
        IValidator<SumCoordinatorOptions> validator, 
        ICancellableCoordinator<SumCoordinatorOptions, TimeBenchmarkResult> coordinator) 
        : base(inputMapper, validator, coordinator)
    {
    }
}
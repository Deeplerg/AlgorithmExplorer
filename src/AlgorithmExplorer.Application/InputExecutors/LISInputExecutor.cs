using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.LIS;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation;

namespace AlgorithmExplorer.Application.InputExecutors;

[ForAlgorithm(AlgorithmType.LIS)]
public class LISInputExecutor : InputExecutorBase<LISCoordinatorOptions, TimeBenchmarkResult>
{
    public LISInputExecutor(
        IMapper<DisplayableOptionInputs, LISCoordinatorOptions> inputMapper, 
        IValidator<LISCoordinatorOptions> validator, 
        ICancellableCoordinator<LISCoordinatorOptions, TimeBenchmarkResult> coordinator) 
        : base(inputMapper, validator, coordinator)
    {
    }
}
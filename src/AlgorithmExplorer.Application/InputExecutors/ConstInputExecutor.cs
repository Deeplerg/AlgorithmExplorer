using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.Const;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation;

namespace AlgorithmExplorer.Application.InputExecutors;

[ForAlgorithm(AlgorithmType.Const)]
public class ConstInputExecutor : InputExecutorBase<ConstCoordinatorOptions, TimeBenchmarkResult>
{
    public ConstInputExecutor(
        IMapper<DisplayableOptionInputs, ConstCoordinatorOptions> inputMapper, 
        IValidator<ConstCoordinatorOptions> validator, 
        ICancellableCoordinator<ConstCoordinatorOptions, TimeBenchmarkResult> coordinator) 
        : base(inputMapper, validator, coordinator)
    {
    }
}
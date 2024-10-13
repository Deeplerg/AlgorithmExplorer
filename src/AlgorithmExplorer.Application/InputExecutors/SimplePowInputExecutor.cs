using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.SimplePow;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Core.Benchmarking.Operations;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation;

namespace AlgorithmExplorer.Application.InputExecutors;

[ForAlgorithm(AlgorithmType.SimplePow)]
public class SimplePowInputExecutor : InputExecutorBase<SimplePowCoordinatorOptions, OperationsBenchmarkResult>
{
    public SimplePowInputExecutor(
        IMapper<DisplayableOptionInputs, SimplePowCoordinatorOptions> inputMapper, 
        IValidator<SimplePowCoordinatorOptions> validator, 
        ICancellableCoordinator<SimplePowCoordinatorOptions, OperationsBenchmarkResult> coordinator) 
        : base(inputMapper, validator, coordinator)
    {
    }
}
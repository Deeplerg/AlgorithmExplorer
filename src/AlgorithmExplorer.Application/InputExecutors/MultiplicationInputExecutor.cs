using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.Multiplication;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation;

namespace AlgorithmExplorer.Application.InputExecutors;

[ForAlgorithm(AlgorithmType.Multiplication)]
public class MultiplicationInputExecutor : InputExecutorBase<MultiplicationCoordinatorOptions, TimeBenchmarkResult>
{
    public MultiplicationInputExecutor(
        IMapper<DisplayableOptionInputs, MultiplicationCoordinatorOptions> inputMapper, 
        IValidator<MultiplicationCoordinatorOptions> validator, 
        ICancellableCoordinator<MultiplicationCoordinatorOptions, TimeBenchmarkResult> coordinator) 
        : base(inputMapper, validator, coordinator)
    {
    }
}
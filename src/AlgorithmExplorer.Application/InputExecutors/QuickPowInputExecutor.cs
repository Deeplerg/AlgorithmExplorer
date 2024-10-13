using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.QuickPow;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Core.Benchmarking.Operations;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation;

namespace AlgorithmExplorer.Application.InputExecutors;

[ForAlgorithm(AlgorithmType.QuickPow)]
public class QuickPowInputExecutor : InputExecutorBase<QuickPowCoordinatorOptions, OperationsBenchmarkResult>
{
    public QuickPowInputExecutor(
        IMapper<DisplayableOptionInputs, QuickPowCoordinatorOptions> inputMapper, 
        IValidator<QuickPowCoordinatorOptions> validator, 
        ICancellableCoordinator<QuickPowCoordinatorOptions, OperationsBenchmarkResult> coordinator) 
        : base(inputMapper, validator, coordinator)
    {
    }
}
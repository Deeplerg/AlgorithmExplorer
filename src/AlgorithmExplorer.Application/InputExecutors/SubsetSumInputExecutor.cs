using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.SubsetSum;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation;

namespace AlgorithmExplorer.Application.InputExecutors;

[ForAlgorithm(AlgorithmType.SubsetSum)]
public class SubsetSumInputExecutor : InputExecutorBase<SubsetSumCoordinatorOptions, TimeBenchmarkResult>
{
    public SubsetSumInputExecutor(
        IMapper<DisplayableOptionInputs, SubsetSumCoordinatorOptions> inputMapper,
        IValidator<SubsetSumCoordinatorOptions> validator,
        ICancellableCoordinator<SubsetSumCoordinatorOptions, TimeBenchmarkResult> coordinator)
        : base(inputMapper, validator, coordinator)
    {
    }
}
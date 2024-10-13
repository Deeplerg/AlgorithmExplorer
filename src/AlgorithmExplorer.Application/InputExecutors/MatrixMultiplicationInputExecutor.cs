using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.ExecutionCoordinators.MatrixMultiplication;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Infrastructure.Configuration;
using FluentValidation;

namespace AlgorithmExplorer.Application.InputExecutors;

[ForAlgorithm(AlgorithmType.MatrixMultiplication)]
public class MatrixMultiplicationInputExecutor : InputExecutorBase<MatrixMultiplicationCoordinatorOptions, TimeBenchmarkResult>
{
    public MatrixMultiplicationInputExecutor(
        IMapper<DisplayableOptionInputs, MatrixMultiplicationCoordinatorOptions> inputMapper, 
        IValidator<MatrixMultiplicationCoordinatorOptions> validator, 
        ICancellableCoordinator<MatrixMultiplicationCoordinatorOptions, TimeBenchmarkResult> coordinator) 
        : base(inputMapper, validator, coordinator)
    {
    }
}
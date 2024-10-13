using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Algorithms.MatrixMultiplication;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.MatrixMultiplication;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.MatrixMultiplication;

public class MatrixMultiplicationCoordinator(
    IDataGenerator<MatrixMultiplicationDataGeneratorOptions, MatrixMultiplicationOptions> generator,
    ICancellableAlgorithm<MatrixMultiplicationOptions, MatrixMultiplicationResult> algorithm,
    ITimeAlgorithmRunner runner)
    : TimeCoordinatorBase<
        MatrixMultiplicationCoordinatorOptions, 
        MatrixMultiplicationOptions, 
        MatrixMultiplicationResult, 
        MatrixMultiplicationDataGeneratorOptions>(
        generator, algorithm, runner)
{
    protected override MatrixMultiplicationDataGeneratorOptions ConstructGeneratorOptions(
        MatrixMultiplicationCoordinatorOptions options,
        int currentIteration)
        => new(currentIteration);
}
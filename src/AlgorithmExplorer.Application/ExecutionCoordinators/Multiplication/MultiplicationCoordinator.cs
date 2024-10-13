using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Algorithms.Multiplication;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.Multiplication;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.Multiplication;

public class MultiplicationCoordinator(
    IDataGenerator<MultiplicationDataGeneratorOptions, MultiplicationOptions> generator,
    ICancellableAlgorithm<MultiplicationOptions, MultiplicationResult> algorithm,
    ITimeAlgorithmRunner runner)
    : SequenceCoordinatorBase<
        MultiplicationCoordinatorOptions, MultiplicationOptions, MultiplicationResult, MultiplicationDataGeneratorOptions>(generator, algorithm, runner)
{
    protected override MultiplicationDataGeneratorOptions ConstructGeneratorOptions(
        MultiplicationCoordinatorOptions options,
        int currentIteration)
        => ConstructInheritedGeneratorOptions(new(), options, currentIteration);
}
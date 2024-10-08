using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Algorithms.BubbleSort;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.BubbleSort;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.BubbleSort;

public class BubbleSortCoordinator(
    IDataGenerator<BubbleSortDataGeneratorOptions, BubbleSortOptions> generator,
    ICancellableAlgorithm<BubbleSortOptions, BubbleSortResult> algorithm,
    ICancellableAlgorithmRunner runner)
    : SequenceCoordinatorBase<
        BubbleSortCoordinatorOptions, BubbleSortOptions, BubbleSortResult, BubbleSortDataGeneratorOptions>(generator, algorithm, runner)
{
    protected override BubbleSortDataGeneratorOptions ConstructGeneratorOptions(
        BubbleSortCoordinatorOptions options,
        int currentIteration)
        => ConstructInheritedGeneratorOptions(new(), options, currentIteration);
}
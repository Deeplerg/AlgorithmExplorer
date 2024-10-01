using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Algorithms.QuickSort;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.QuickSortAlgorithm;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.QuickSort;

public class QuickSortCoordinator(
    IDataGenerator<QuickSortDataGeneratorOptions, QuickSortOptions> generator,
    ICancellableAlgorithm<QuickSortOptions, QuickSortResult> algorithm,
    ICancellableAlgorithmRunner runner)
    : CoordinatorBase<
        QuickSortCoordinatorOptions, QuickSortOptions, QuickSortResult, QuickSortDataGeneratorOptions>(generator, algorithm, runner)
{
    protected override QuickSortDataGeneratorOptions ConstructGeneratorOptions(
        QuickSortCoordinatorOptions options,
        int currentIteration)
        => new(currentIteration);
}
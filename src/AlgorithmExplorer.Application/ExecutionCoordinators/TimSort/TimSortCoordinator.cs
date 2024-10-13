using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Algorithms.TimSort;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.TimSort;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.TimSort;

public class TimSortCoordinator(
    IDataGenerator<TimSortDataGeneratorOptions, TimSortOptions> generator,
    ICancellableAlgorithm<TimSortOptions, TimSortResult> algorithm,
    ITimeAlgorithmRunner runner)
    : SequenceCoordinatorBase<
        TimSortCoordinatorOptions, TimSortOptions, TimSortResult, TimSortDataGeneratorOptions>(generator, algorithm, runner)
{
    protected override TimSortDataGeneratorOptions ConstructGeneratorOptions(
        TimSortCoordinatorOptions options,
        int currentIteration)
        => ConstructInheritedGeneratorOptions(new(), options, currentIteration);
}
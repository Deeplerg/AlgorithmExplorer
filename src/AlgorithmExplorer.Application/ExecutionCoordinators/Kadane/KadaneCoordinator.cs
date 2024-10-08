using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Algorithms.Kadane;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.Kadane;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.Kadane;

public class KadaneCoordinator(
    IDataGenerator<KadaneDataGeneratorOptions, KadaneOptions> generator,
    ICancellableAlgorithm<KadaneOptions, KadaneResult> algorithm,
    ICancellableAlgorithmRunner runner)
    : SequenceCoordinatorBase<
        KadaneCoordinatorOptions, KadaneOptions, KadaneResult, KadaneDataGeneratorOptions>(generator, algorithm, runner)
{
    protected override KadaneDataGeneratorOptions ConstructGeneratorOptions(
        KadaneCoordinatorOptions options,
        int currentIteration)
        => ConstructInheritedGeneratorOptions(new(), options, currentIteration);
}
using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Algorithms.Gorner;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.Gorner;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.Gorner;

public class GornerCoordinator(
    IDataGenerator<GornerDataGeneratorOptions, GornerOptions> generator,
    ICancellableAlgorithm<GornerOptions, GornerResult> algorithm,
    ICancellableAlgorithmRunner runner)
    : SequenceCoordinatorBase<
        GornerCoordinatorOptions, GornerOptions, GornerResult, GornerDataGeneratorOptions>(generator, algorithm, runner)
{
    protected override GornerDataGeneratorOptions ConstructGeneratorOptions(
        GornerCoordinatorOptions options,
        int currentIteration)
        => ConstructInheritedGeneratorOptions(new(), options, currentIteration);
}
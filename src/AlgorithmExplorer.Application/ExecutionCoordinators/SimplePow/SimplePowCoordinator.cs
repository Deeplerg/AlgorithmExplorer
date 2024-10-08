using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Algorithms.SimplePow;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.SimplePow;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.SimplePow;

public class SimplePowCoordinator(
    IDataGenerator<SimplePowDataGeneratorOptions, SimplePowOptions> generator,
    ICancellableAlgorithm<SimplePowOptions, SimplePowResult> algorithm,
    ICancellableAlgorithmRunner runner)
    : PowCoordinatorBase<
        SimplePowCoordinatorOptions, SimplePowOptions, SimplePowResult, SimplePowDataGeneratorOptions>(generator, algorithm, runner)
{
    protected override SimplePowDataGeneratorOptions ConstructGeneratorOptions(
        SimplePowCoordinatorOptions options,
        int currentIteration)
        => ConstructInheritedGeneratorOptions(new(), options, currentIteration);
}
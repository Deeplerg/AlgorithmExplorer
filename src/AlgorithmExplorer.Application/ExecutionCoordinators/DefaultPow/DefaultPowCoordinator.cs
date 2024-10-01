using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Algorithms.DefaultPow;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.DefaultPow;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.DefaultPow;

public class DefaultPowCoordinator(
    IDataGenerator<DefaultPowDataGeneratorOptions, DefaultPowOptions> generator,
    ICancellableAlgorithm<DefaultPowOptions, DefaultPowResult> algorithm,
    ICancellableAlgorithmRunner runner)
    : CoordinatorBase<
        DefaultPowCoordinatorOptions, DefaultPowOptions, DefaultPowResult, DefaultPowDataGeneratorOptions>(generator, algorithm, runner)
{
    protected override DefaultPowDataGeneratorOptions ConstructGeneratorOptions(
        DefaultPowCoordinatorOptions options,
        int currentIteration)
        => new(currentIteration, options.Number);
}
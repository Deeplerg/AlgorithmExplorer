using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Algorithms.QuickPow;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.QuickPow;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.QuickPow;

public class QuickPowCoordinator(
    IDataGenerator<QuickPowDataGeneratorOptions, QuickPowOptions> generator,
    ICancellableAlgorithm<QuickPowOptions, QuickPowResult> algorithm,
    ITimeAlgorithmRunner runner)
    : PowCoordinatorBase<
        QuickPowCoordinatorOptions, QuickPowOptions, QuickPowResult, QuickPowDataGeneratorOptions>(generator, algorithm, runner)
{
    protected override QuickPowDataGeneratorOptions ConstructGeneratorOptions(
        QuickPowCoordinatorOptions options,
        int currentIteration)
        => ConstructInheritedGeneratorOptions(new(), options, currentIteration);
}
using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Algorithms.Const;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.Const;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.Const;

public class ConstCoordinator(
    IDataGenerator<ConstDataGeneratorOptions, ConstOptions> generator,
    ICancellableAlgorithm<ConstOptions, ConstResult> algorithm,
    ITimeAlgorithmRunner runner)
    : CoordinatorBase<
        ConstCoordinatorOptions, ConstOptions, ConstResult, ConstDataGeneratorOptions>(generator, algorithm, runner)
{
    protected override ConstDataGeneratorOptions ConstructGeneratorOptions(
        ConstCoordinatorOptions options,
        int currentIteration)
        => new();
}
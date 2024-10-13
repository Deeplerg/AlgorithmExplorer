using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Algorithms.LIS;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.LIS;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.LIS;

public class LISCoordinator(
    IDataGenerator<LISDataGeneratorOptions, LISOptions> generator,
    ICancellableAlgorithm<LISOptions, LISResult> algorithm,
    ITimeAlgorithmRunner runner)
    : SequenceCoordinatorBase<
        LISCoordinatorOptions, LISOptions, LISResult, LISDataGeneratorOptions>(generator, algorithm, runner)
{
    protected override LISDataGeneratorOptions ConstructGeneratorOptions(
        LISCoordinatorOptions options,
        int currentIteration)
        => ConstructInheritedGeneratorOptions(new(), options, currentIteration);
}
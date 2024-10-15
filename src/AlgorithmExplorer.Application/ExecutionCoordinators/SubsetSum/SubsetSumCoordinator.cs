using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Algorithms.SubsetSum;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.SubsetSum;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.SubsetSum;

public class SubsetSumCoordinator(
    IDataGenerator<SubsetSumDataGeneratorOptions, SubsetSumOptions> generator,
    ICancellableAlgorithm<SubsetSumOptions, SubsetSumResult> algorithm,
    ITimeAlgorithmRunner runner)
    : SequenceCoordinatorBase<
        SubsetSumCoordinatorOptions, SubsetSumOptions, SubsetSumResult, SubsetSumDataGeneratorOptions>(generator, algorithm, runner)
{
    protected override SubsetSumDataGeneratorOptions ConstructGeneratorOptions(
        SubsetSumCoordinatorOptions options,
        int currentIteration)
        => ConstructInheritedGeneratorOptions(new(), options, currentIteration);
}
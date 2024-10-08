using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Algorithms.Sum;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.Sum;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.Sum;

public class SumCoordinator(
    IDataGenerator<SumDataGeneratorOptions, SumOptions> generator,
    ICancellableAlgorithm<SumOptions, SumResult> algorithm,
    ICancellableAlgorithmRunner runner)
    : SequenceCoordinatorBase<
        SumCoordinatorOptions, SumOptions, SumResult, SumDataGeneratorOptions>(generator, algorithm, runner)
{
    protected override SumDataGeneratorOptions ConstructGeneratorOptions(
        SumCoordinatorOptions options,
        int currentIteration)
        => ConstructInheritedGeneratorOptions(new(), options, currentIteration);
}
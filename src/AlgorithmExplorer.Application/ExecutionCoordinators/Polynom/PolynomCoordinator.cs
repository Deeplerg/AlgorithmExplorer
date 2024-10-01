using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Algorithms.Polynom;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.Polynom;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.Polynom;

public class PolynomCoordinator(
    IDataGenerator<PolynomDataGeneratorOptions, PolynomOptions> generator,
    ICancellableAlgorithm<PolynomOptions, PolynomResult> algorithm,
    ICancellableAlgorithmRunner runner)
    : CoordinatorBase<
        PolynomCoordinatorOptions, PolynomOptions, PolynomResult, PolynomDataGeneratorOptions>(generator, algorithm, runner)
{
    protected override PolynomDataGeneratorOptions ConstructGeneratorOptions(
        PolynomCoordinatorOptions options,
        int currentIteration)
        => new(currentIteration);
}
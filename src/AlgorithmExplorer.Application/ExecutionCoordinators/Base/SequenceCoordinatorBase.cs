using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.Base;

public abstract class SequenceCoordinatorBase<
    TCoordinatorOptions,
    TRunOptions,
    TResult,
    TDataGeneratorOptions>
    : CoordinatorBase<TCoordinatorOptions, TRunOptions, TResult, TDataGeneratorOptions>
    where TRunOptions : class
    where TCoordinatorOptions : CoordinatorOptionsBase
    where TDataGeneratorOptions : SequenceDataGeneratorOptionsBase
{
    protected SequenceCoordinatorBase(
        IDataGenerator<TDataGeneratorOptions, TRunOptions> generator,
        ICancellableAlgorithm<TRunOptions, TResult> algorithm,
        ICancellableAlgorithmRunner runner)
        : base(generator, algorithm, runner)
    {
    }

    protected TDataGeneratorOptions ConstructInheritedGeneratorOptions(
        TDataGeneratorOptions emptyInheritedOptions,
        TCoordinatorOptions coordinatorOptions,
        int currentIteration)
    {
        var @base = ConstructBaseGeneratorOptions(coordinatorOptions, currentIteration);

        var castOptions = (SequenceDataGeneratorOptionsBase)emptyInheritedOptions;
        castOptions.Count = @base.Count;

        return (TDataGeneratorOptions)castOptions;
    }

    protected SequenceDataGeneratorOptionsBase ConstructBaseGeneratorOptions(
        TCoordinatorOptions options, int currentIteration)
        => new(currentIteration);
}
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.Base;

public abstract class PowCoordinatorBase<
    TCoordinatorOptions,
    TRunOptions,
    TResult,
    TDataGeneratorOptions>
    : CoordinatorBase<TCoordinatorOptions, TRunOptions, TResult, TDataGeneratorOptions>
    where TRunOptions : class
    where TCoordinatorOptions : CoordinatorOptionsBase
    where TDataGeneratorOptions : PowDataGeneratorOptionsBase
{
    protected PowCoordinatorBase(
        IDataGenerator<TDataGeneratorOptions, TRunOptions> generator,
        ICancellableAlgorithm<TRunOptions, TResult> algorithm,
        ITimeAlgorithmRunner runner)
        : base(generator, algorithm, runner)
    {
    }

    protected TDataGeneratorOptions ConstructInheritedGeneratorOptions(
        TDataGeneratorOptions emptyInheritedOptions,
        TCoordinatorOptions coordinatorOptions,
        int currentIteration)
    {
        var @base = ConstructBaseGeneratorOptions(coordinatorOptions, currentIteration);

        var castOptions = (PowDataGeneratorOptionsBase)emptyInheritedOptions;
        castOptions.Count = @base.Count;

        return (TDataGeneratorOptions)castOptions;
    }

    protected PowDataGeneratorOptionsBase ConstructBaseGeneratorOptions(
        TCoordinatorOptions options, int currentIteration)
        => new(currentIteration, options.IterationCount);
}
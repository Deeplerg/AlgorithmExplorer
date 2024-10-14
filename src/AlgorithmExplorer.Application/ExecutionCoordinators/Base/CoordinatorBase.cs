using System.Runtime.CompilerServices;
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Core.DataGenerators;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.Base;

public abstract class CoordinatorBase<
    TCoordinatorOptions,
    TRunOptions,
    TResult,
    TDataGeneratorOptions,
    TCoordinatorResult> 
    : ICancellableCoordinator<TCoordinatorOptions, TCoordinatorResult>
    where TRunOptions : class
    where TCoordinatorOptions : CoordinatorOptionsBase
{
    protected readonly IDataGenerator<TDataGeneratorOptions, TRunOptions> _generator;
    protected readonly ICancellableAlgorithm<TRunOptions, TResult> _algorithm;

    protected IAsyncEnumerable<NumberedRunOptions<TRunOptions>>? _data = null;
    protected int _totalDataCount = 0;
    
    protected CoordinatorBase(
        IDataGenerator<TDataGeneratorOptions, TRunOptions> generator,
        ICancellableAlgorithm<TRunOptions, TResult> algorithm)
    {
        _generator = generator;
        _algorithm = algorithm;
    }
    
    public virtual async Task<bool> PrepareDataAsync(TCoordinatorOptions options, CancellationToken token)
    {
        _data = null;
        _totalDataCount = 0;
        
        var generationOptions = new List<(TCoordinatorOptions coordinatorOptions, int iteration)>();

        int totalIterations = options.IterationCount;
        int cumulativeStep = options.Step;
        bool addedMaxIteration = false;
        
        for (int i = 1; i < totalIterations + 1; )
        {
            if (i == totalIterations)
                addedMaxIteration = true;
            
            if (token.IsCancellationRequested)
            {
                return false;
            }

            generationOptions.Add((options, i));
            _totalDataCount++;

            switch (options.StepType)
            {
                case StepType.Additive:
                    i += options.Step;
                    break;

                case StepType.Cumulative:
                    i += cumulativeStep;
                    break;

                case StepType.Multiplicative:
                    i *= options.Step;
                    break;

                default:
                    throw new ArgumentException($"Unknown {nameof(StepType)} value: {options.StepType}");
            }
            cumulativeStep += options.Step;
        }

        if (!addedMaxIteration)
        {
            generationOptions.Add((options, totalIterations));
        }

        _data = PrepareEnumerableAsync(generationOptions, token);

        return true;
    }

    public abstract Task<TCoordinatorResult> RunAsync(
        CancellationToken token, IProgress<BenchmarkProgressReport>? progress = null);

    protected abstract TDataGeneratorOptions ConstructGeneratorOptions(TCoordinatorOptions options,
        int currentIteration);

    protected virtual async Task<TRunOptions> GenerateAsync(TDataGeneratorOptions options)
    {
        return await Task.Run(() => _generator.Generate(options));
    }

    protected void GuardAgainstNoData()
    {
        if (_data is null || _totalDataCount == 0) 
            throw new InvalidOperationException("Data has not been generated yet.");
    }

    protected virtual async IAsyncEnumerable<NumberedRunOptions<TRunOptions>> PrepareEnumerableAsync(
        List<(TCoordinatorOptions coordinatorOptions, int iteration)> generationOptions, 
        [EnumeratorCancellation] CancellationToken token)
    {
        foreach (var generationOption in generationOptions)
        {
            token.ThrowIfCancellationRequested();
            
            yield return await GenerateRunOptionsAsync(
                generationOption.coordinatorOptions, generationOption.iteration);
        }
    }
    
    private async Task<NumberedRunOptions<TRunOptions>> GenerateRunOptionsAsync(TCoordinatorOptions options, int iteration)
    {
        var generatorOptions = ConstructGeneratorOptions(options, iteration);
        var runOptions = await GenerateAsync(generatorOptions);
        return new NumberedRunOptions<TRunOptions>(runOptions, iteration);
    }
}
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

    protected readonly List<NumberedRunOptions<TRunOptions>> _data = new();
    
    protected CoordinatorBase(
        IDataGenerator<TDataGeneratorOptions, TRunOptions> generator,
        ICancellableAlgorithm<TRunOptions, TResult> algorithm)
    {
        _generator = generator;
        _algorithm = algorithm;
    }
    
    public virtual async Task<bool> PrepareDataAsync(TCoordinatorOptions options, CancellationToken token)
    {
        _data.Clear();

        int totalIterations = options.IterationCount;
        int cumulativeStep = options.Step;
        bool addedMaxIteration = false;
        
        for (int i = 1; i < totalIterations + 1; )
        {
            if (i == totalIterations)
                addedMaxIteration = true;
            
            if (token.IsCancellationRequested)
            {
                _data.Clear();
                return false;
            }

            var runOptions = await GenerateRunOptionsAsync(options, i);
            _data.Add(runOptions);

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
            var runOptions = await GenerateRunOptionsAsync(options, totalIterations);
            _data.Add(runOptions);
        }

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
        if (!_data.Any()) throw new InvalidOperationException("Data has not been generated yet.");
    }
    
    private async Task<NumberedRunOptions<TRunOptions>> GenerateRunOptionsAsync(TCoordinatorOptions options, int iteration)
    {
        var generatorOptions = ConstructGeneratorOptions(options, iteration);
        var runOptions = await GenerateAsync(generatorOptions);
        return new NumberedRunOptions<TRunOptions>(runOptions, iteration);
    }
}
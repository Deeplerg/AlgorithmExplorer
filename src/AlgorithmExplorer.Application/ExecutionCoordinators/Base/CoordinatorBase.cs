using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.DataGenerators;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.Base;

public abstract class CoordinatorBase<
    TCoordinatorOptions,
    TRunOptions,
    TResult,
    TDataGeneratorOptions> 
    : ICancellableCoordinator<TCoordinatorOptions>
    where TRunOptions : class
    where TCoordinatorOptions : CoordinatorOptionsBase
{
    protected readonly IDataGenerator<TDataGeneratorOptions, TRunOptions> _generator;
    protected readonly ICancellableAlgorithm<TRunOptions, TResult> _algorithm;
    protected readonly ICancellableAlgorithmRunner _runner;

    protected readonly List<NumberedRunOptions<TRunOptions>> _data = new();
    
    protected CoordinatorBase(
        IDataGenerator<TDataGeneratorOptions, TRunOptions> generator,
        ICancellableAlgorithm<TRunOptions, TResult> algorithm,
        ICancellableAlgorithmRunner runner)
    {
        _generator = generator;
        _algorithm = algorithm;
        _runner = runner;
    }
    
    public virtual async Task<bool> PrepareDataAsync(TCoordinatorOptions options, CancellationToken token)
    {
        _data.Clear();

        int iterations = options.IterationCount;
        int cumulativeStep = options.Step;
        bool addedMaxIteration = false;
        for (int i = 1; i < iterations + 1; )
        {
            if (i == iterations)
                addedMaxIteration = true;
            
            if (token.IsCancellationRequested)
            {
                _data.Clear();
                return false;
            }

            var generatorOptions = ConstructGeneratorOptions(options, i);
            var runOptions = await GenerateAsync(generatorOptions);
            var numberedRunOptions = new NumberedRunOptions<TRunOptions>(runOptions, i);
            _data.Add(numberedRunOptions);

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
            var generatorOptions = ConstructGeneratorOptions(options, iterations);
            var runOptions = await GenerateAsync(generatorOptions);
            var numberedRunOptions = new NumberedRunOptions<TRunOptions>(runOptions, iterations);
            _data.Add(numberedRunOptions);
        }

        return true;
    }

    public virtual async Task<BenchmarkResult> RunAsync(
        CancellationToken token,
        IProgress<BenchmarkProgressReport>? progress = null)
    {
        if (!_data.Any()) throw new InvalidOperationException("Data has not been generated yet.");
        
        var runResult = await _runner.RunAsync<ICancellableAlgorithm<TRunOptions, TResult>, TRunOptions, TResult>(
            _algorithm, _data, token, progress);

        return runResult;
    }

    protected abstract TDataGeneratorOptions ConstructGeneratorOptions(TCoordinatorOptions options,
        int currentIteration);

    protected virtual async Task<TRunOptions> GenerateAsync(TDataGeneratorOptions options)
    {
        return await Task.Run(() => _generator.Generate(options));
    }
}
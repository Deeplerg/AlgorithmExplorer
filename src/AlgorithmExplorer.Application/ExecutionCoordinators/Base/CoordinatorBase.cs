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

    protected readonly List<TRunOptions> _data = new();
    
    public CoordinatorBase(
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
        
        for (int i = 1; i < options.IterationCount + 1; i++)
        {
            if (token.IsCancellationRequested)
            {
                _data.Clear();
                return false;
            }

            var generatorOptions = ConstructGeneratorOptions(options, i);
            var runOptions = await GenerateAsync(generatorOptions);
            _data.Add(runOptions);
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
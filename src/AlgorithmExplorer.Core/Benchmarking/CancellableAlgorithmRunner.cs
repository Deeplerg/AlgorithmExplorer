using System.Diagnostics;
using AlgorithmExplorer.Core.Algorithms;

namespace AlgorithmExplorer.Core.Benchmarking;

public class CancellableAlgorithmRunner : ICancellableAlgorithmRunner
{
    public async Task<BenchmarkResult> RunAsync<TAlgorithm, TRunOptions, TResult>(
        TAlgorithm algorithm, 
        IEnumerable<NumberedRunOptions<TRunOptions>> options,
        CancellationToken cancellationToken, 
        IProgress<BenchmarkProgressReport>? progress = null) 
        where TAlgorithm : ICancellableAlgorithm<TRunOptions, TResult> 
        where TRunOptions : class
    {
        var runResults = new List<AlgorithmRunResult>();
        TimeSpan totalTimeElapsed = TimeSpan.Zero;
        bool isCancelled = false;
        
        var stopwatch = new Stopwatch();
        
        var enumeratedOptions = options.ToList(); 
        
        for (int i = 0; i < enumeratedOptions.Count; i++)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                isCancelled = true;
                break;
            }
            
            var currentOptions = enumeratedOptions[i];
            
            stopwatch.Restart();
            
            var algorithmResult = await Task.Run(() => algorithm.Run(currentOptions.RunOptions, cancellationToken));
            
            stopwatch.Stop();
            totalTimeElapsed += stopwatch.Elapsed;
            
            var runResult = new AlgorithmRunResult(
                stopwatch.Elapsed, algorithmResult.IsCancelled, currentOptions.DataLength);
            runResults.Add(runResult);
            
            progress?.Report(new BenchmarkProgressReport(i + 1));
        }

        return new BenchmarkResult(runResults, isCancelled, totalTimeElapsed);
    }
}
using System.Diagnostics;
using AlgorithmExplorer.Core.Algorithms;

namespace AlgorithmExplorer.Core.Benchmarking.Time;

public class TimeAlgorithmRunner : ITimeAlgorithmRunner
{
    public async Task<TimeBenchmarkResult> RunAsync<TAlgorithm, TRunOptions, TResult>(
        TimeRunnerOptions<TAlgorithm, TRunOptions, TResult> options, 
        CancellationToken cancellationToken,
        IProgress<BenchmarkProgressReport>? progress = null) 
        where TAlgorithm : ICancellableAlgorithm<TRunOptions, TResult> 
        where TRunOptions : class
    {
        var runResults = new List<TimeAlgorithmRunResult>();
        TimeSpan totalTimeElapsed = TimeSpan.Zero;
        bool isCancelled = false;
        
        var stopwatch = new Stopwatch();
        
        var enumeratedOptions = options.RunOptions.ToList(); 
        
        for (int i = 0; i < enumeratedOptions.Count; i++)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                isCancelled = true;
                break;
            }
            
            var currentOptions = enumeratedOptions[i];
            var algorithm = options.Algorithm;
            
            stopwatch.Restart();
            
            var algorithmResult = await Task.Run(() => algorithm.Run(currentOptions.RunOptions, cancellationToken));
            
            stopwatch.Stop();
            totalTimeElapsed += stopwatch.Elapsed;
            
            var runResult = new TimeAlgorithmRunResult(
                stopwatch.Elapsed, algorithmResult.IsCancelled, currentOptions.DataLength);
            runResults.Add(runResult);
            
            progress?.Report(new BenchmarkProgressReport(i + 1));
        }

        return new TimeBenchmarkResult(runResults, isCancelled, totalTimeElapsed);
    }
}
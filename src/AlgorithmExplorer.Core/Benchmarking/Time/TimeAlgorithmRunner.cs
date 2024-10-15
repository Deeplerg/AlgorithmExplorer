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

        try
        {
            int i = 0;
            await foreach (var currentOptions in options.RunOptions.WithCancellation(cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    isCancelled = true;
                    break;
                }

                var algorithm = options.Algorithm;

                stopwatch.Restart();

                var algorithmResult = await Task.Run(() => algorithm.Run(currentOptions.RunOptions, cancellationToken));

                stopwatch.Stop();
                totalTimeElapsed += stopwatch.Elapsed;

                var runResult = new TimeAlgorithmRunResult(
                    stopwatch.Elapsed, algorithmResult.IsCancelled, currentOptions.DataLength);
                runResults.Add(runResult);

                progress?.Report(new BenchmarkProgressReport(
                    RunsCompleted: + 1, TotalRuns: options.TotalOptionsCount));

                i++;
            }
        }
        catch (OperationCanceledException)
        {
            isCancelled = true;
        }

        return new TimeBenchmarkResult(runResults, isCancelled, totalTimeElapsed);
    }
}
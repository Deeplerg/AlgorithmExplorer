using System.Diagnostics;
using AlgorithmExplorer.Core.Algorithms;

namespace AlgorithmExplorer.Core.Benchmarking.Operations;

public class OperationsAlgorithmRunner : IOperationsAlgorithmRunner
{
    public async Task<OperationsBenchmarkResult> RunAsync<TAlgorithm, TRunOptions, TResult>(
        OperationsRunnerOptions<TAlgorithm, TRunOptions, TResult> options, 
        CancellationToken cancellationToken,
        IProgress<BenchmarkProgressReport>? progress = null) 
        where TAlgorithm : ICancellableAlgorithm<TRunOptions, TResult> 
        where TRunOptions : class
        where TResult : OperationsResultBase
    {
        long totalOperations = 0;
        var runResults = new List<OperationsAlgorithmRunResult>();
        bool isCancelled = false;
        
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
            
            var algorithmResult = await Task.Run(() => algorithm.Run(currentOptions.RunOptions, cancellationToken));
            
            long operations = algorithmResult.Result?.Operations ?? 0;
            totalOperations += operations;
            
            var runResult = new OperationsAlgorithmRunResult(
                operations, algorithmResult.IsCancelled, currentOptions.DataLength);
            runResults.Add(runResult);
            
            progress?.Report(new BenchmarkProgressReport(i + 1));
        }

        return new OperationsBenchmarkResult(runResults, isCancelled, totalOperations);
    }
}
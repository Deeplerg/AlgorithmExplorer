using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Core.Benchmarking;
using FluentValidation.Results;

namespace AlgorithmExplorer.Application.InputExecutors;

public interface IInputExecutor
{
    void SetInput(DisplayableOptionInputs inputs);
    
    ValidationResult ValidateInput();
    
    Task<bool> PrepareDataAsync(CancellationToken cancellationToken);
    
    Task<BenchmarkResult> RunAsync(
        CancellationToken cancellationToken,
        IProgress<BenchmarkProgressReport>? progress = null);
    
    BenchmarkResult? BenchmarkResult { get; }
}
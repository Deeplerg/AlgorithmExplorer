using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.Benchmarking.Time;
using FluentValidation.Results;

namespace AlgorithmExplorer.Application.InputExecutors;

public interface IInputExecutor<TResult>
{
    void SetInput(DisplayableOptionInputs inputs);
    
    ValidationResult ValidateInput();
    
    Task<bool> PrepareDataAsync(CancellationToken cancellationToken);
    
    Task<TResult> RunAsync(
        CancellationToken cancellationToken,
        IProgress<BenchmarkProgressReport>? progress = null);
}
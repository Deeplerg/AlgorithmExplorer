﻿using AlgorithmExplorer.Application.ExecutionCoordinators;
using AlgorithmExplorer.Application.Mappers;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.Benchmarking.Time;
using FluentValidation;
using FluentValidation.Results;

namespace AlgorithmExplorer.Application.InputExecutors;

public class InputExecutorBase<TCoordinatorOptions, TResult> : IInputExecutor<TResult>
    where TCoordinatorOptions : class
{
    protected readonly IMapper<DisplayableOptionInputs, TCoordinatorOptions> _inputMapper;
    protected readonly IValidator<TCoordinatorOptions> _validator;
    protected readonly ICancellableCoordinator<TCoordinatorOptions, TResult> _coordinator;

    protected TCoordinatorOptions? _input = null;

    public InputExecutorBase(
        IMapper<DisplayableOptionInputs, TCoordinatorOptions> inputMapper,
        IValidator<TCoordinatorOptions> validator,
        ICancellableCoordinator<TCoordinatorOptions, TResult> coordinator)
    {
        _inputMapper = inputMapper;
        _validator = validator;
        _coordinator = coordinator;
    }
    
    public virtual void SetInput(DisplayableOptionInputs inputs)
    {
        _input = _inputMapper.Map(inputs);
    }

    public virtual ValidationResult ValidateInput()
    {
        GuardAgainstInputNull();
        
        return _validator.Validate(_input!);
    }

    public virtual async Task<bool> PrepareDataAsync(CancellationToken cancellationToken)
    {
        GuardAgainstInputNull();
        
        return await _coordinator.PrepareDataAsync(_input!, cancellationToken);
    }

    public virtual async Task<TResult> RunAsync(CancellationToken cancellationToken, IProgress<BenchmarkProgressReport>? progress = null)
    {
        GuardAgainstInputNull();

        var benchmarkResult = await _coordinator.RunAsync(cancellationToken, progress);
        
        return benchmarkResult;
    }

    protected void GuardAgainstInputNull()
    {
        if (_input is null) ThrowMethodNotCalled(nameof(_input), nameof(SetInput));
    }

    protected void ThrowMethodNotCalled(string paramName, string methodName)
        => throw new ArgumentNullException(paramName, $"Call {methodName} first.");
}
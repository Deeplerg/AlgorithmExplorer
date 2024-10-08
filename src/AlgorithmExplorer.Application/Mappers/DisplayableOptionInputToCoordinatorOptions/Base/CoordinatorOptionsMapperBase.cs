using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;

public abstract class CoordinatorOptionsMapperBase<TOptions>(
    AlgorithmType expectedType,
    int expectedInputCount) : IMapper<DisplayableOptionInputs, TOptions>
    where TOptions : CoordinatorOptionsBase
{
    protected const int BaseExpectedInputCount = 1;

    public virtual TOptions Map(DisplayableOptionInputs inputs)
    {
        if(inputs.OptionName != expectedType)
            throw new ArgumentException(
                $"Cannot handle current {nameof(AlgorithmType)}. Must be {expectedType}.");
        
        int inputCount = inputs.Inputs.Count;
        if (inputCount != expectedInputCount)
            throw new ArgumentException(
                $"Invalid input count. Expected: {expectedInputCount}, received: {inputCount}");

        return Map(inputs.Inputs);
    }

    protected abstract TOptions Map(IEnumerable<DisplayableOptionInput> inputs);
    
    protected virtual CoordinatorOptionsBase MapBase(IEnumerable<DisplayableOptionInput> inputs)
    {
        var iterationCount = MatchDisplayName(inputs, "iterations");

        return new CoordinatorOptionsBase
        {
            IterationCount = int.Parse(iterationCount.Input)
        };
    }

    protected virtual TOptions MapInherited(TOptions emptyInheritedOptions, IEnumerable<DisplayableOptionInput> inputs)
    {
        var @base = MapBase(inputs);

        var castOptions = (CoordinatorOptionsBase)emptyInheritedOptions;
        castOptions.IterationCount = @base.IterationCount;

        return (TOptions)castOptions;
    }
    
    protected DisplayableOptionInput MatchDisplayName(IEnumerable<DisplayableOptionInput> inputs, string displayName)
        => inputs.First(x => 
            string.Equals(x.Option.DisplayName, displayName, StringComparison.OrdinalIgnoreCase));
}
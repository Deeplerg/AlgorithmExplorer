using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;

public abstract class CoordinatorOptionsMapperBase<TOptions>(
    AlgorithmType expectedType,
    int expectedInputCount) : IMapper<DisplayableOptionInputs, TOptions>
{
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
    
    protected DisplayableOptionInput MatchDisplayName(IEnumerable<DisplayableOptionInput> inputs, string displayName)
        => inputs.First(x => 
            string.Equals(x.Option.DisplayName, displayName, StringComparison.OrdinalIgnoreCase));
}
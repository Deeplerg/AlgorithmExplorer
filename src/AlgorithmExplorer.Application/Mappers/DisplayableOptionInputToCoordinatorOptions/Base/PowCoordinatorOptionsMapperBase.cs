using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;

public abstract class PowCoordinatorOptionsMapperBase<TOptions>(
    AlgorithmType expectedType,
    int expectedInputCount) : CoordinatorOptionsMapperBase<TOptions>(expectedType, expectedInputCount)
    where TOptions : PowCoordinatorOptionsBase
{
    protected const int PowExpectedInputCount = BaseExpectedInputCount + 1;

    protected virtual int MapNumber(IEnumerable<DisplayableOptionInput> inputs)
    {
        var number = MatchDisplayName(inputs, "number");
        return int.Parse(number.Input);
    }

    protected override TOptions MapInherited(TOptions emptyInheritedOptions, IEnumerable<DisplayableOptionInput> inputs)
    {
        var enumeratedInputs = inputs.ToList();
            
        var baseInherited = base.MapInherited(emptyInheritedOptions, enumeratedInputs);

        var castOptions = (PowCoordinatorOptionsBase)baseInherited;
        castOptions.Number = MapNumber(enumeratedInputs);

        return (TOptions)castOptions;
    }
}
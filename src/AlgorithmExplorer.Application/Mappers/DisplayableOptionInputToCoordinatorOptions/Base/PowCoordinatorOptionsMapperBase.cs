using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;

public abstract class PowCoordinatorOptionsMapperBase<TOptions>(
    AlgorithmType expectedType,
    int expectedInputCount) : CoordinatorOptionsMapperBase<TOptions>(expectedType, expectedInputCount)
{
    protected virtual int MapNumber(IEnumerable<DisplayableOptionInput> inputs)
    {
        var number = MatchDisplayName(inputs, "number");
        return int.Parse(number.Input);
    }
}
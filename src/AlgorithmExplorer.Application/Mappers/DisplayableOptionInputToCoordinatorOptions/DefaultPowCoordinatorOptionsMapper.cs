using AlgorithmExplorer.Application.ExecutionCoordinators.DefaultPow;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class DefaultPowCoordinatorOptionsMapper() :
    PowCoordinatorOptionsMapperBase<DefaultPowCoordinatorOptions>(
        expectedType: AlgorithmType.DefaultPow,
        expectedInputCount: 2)
{
    protected override DefaultPowCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
    {
        var displayableOptionInputs = inputs.ToList();
        return new(MapBase(displayableOptionInputs).IterationCount, MapNumber(displayableOptionInputs));
    }
}

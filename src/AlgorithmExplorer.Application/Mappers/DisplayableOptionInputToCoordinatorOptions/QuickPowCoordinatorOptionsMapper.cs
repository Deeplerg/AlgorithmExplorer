using AlgorithmExplorer.Application.ExecutionCoordinators.QuickPow;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class QuickPowCoordinatorOptionsMapper() :
    PowCoordinatorOptionsMapperBase<QuickPowCoordinatorOptions>(
        expectedType: AlgorithmType.QuickPow,
        expectedInputCount: 2)
{
    protected override QuickPowCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
    {
        var displayableOptionInputs = inputs.ToList();
        return new(MapBase(displayableOptionInputs).IterationCount, MapNumber(displayableOptionInputs));
    }
}

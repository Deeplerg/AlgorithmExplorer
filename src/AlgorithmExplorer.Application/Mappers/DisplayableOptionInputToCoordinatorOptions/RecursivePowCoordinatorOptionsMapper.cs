using AlgorithmExplorer.Application.ExecutionCoordinators.RecursivePow;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class RecursivePowCoordinatorOptionsMapper() :
    PowCoordinatorOptionsMapperBase<RecursivePowCoordinatorOptions>(
        expectedType: AlgorithmType.RecursivePow,
        expectedInputCount: 2)
{
    protected override RecursivePowCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
    {
        var displayableOptionInputs = inputs.ToList();
        return new(MapBase(displayableOptionInputs).IterationCount, MapNumber(displayableOptionInputs));
    }
}

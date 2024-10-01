using AlgorithmExplorer.Application.ExecutionCoordinators.SimplePow;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class SimplePowCoordinatorOptionsMapper() :
    PowCoordinatorOptionsMapperBase<SimplePowCoordinatorOptions>(
        expectedType: AlgorithmType.SimplePow,
        expectedInputCount: 2)
{
    protected override SimplePowCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
    {
        var displayableOptionInputs = inputs.ToList();
        return new(MapBase(displayableOptionInputs).IterationCount, MapNumber(displayableOptionInputs));
    }
}

using AlgorithmExplorer.Application.ExecutionCoordinators.LIS;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class LISCoordinatorOptionsMapper() :
    CoordinatorOptionsMapperBase<LISCoordinatorOptions>(
        expectedType: AlgorithmType.LIS,
        expectedInputCount: 1)
{
    protected override LISCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
        => new(MapBase(inputs).IterationCount);
}

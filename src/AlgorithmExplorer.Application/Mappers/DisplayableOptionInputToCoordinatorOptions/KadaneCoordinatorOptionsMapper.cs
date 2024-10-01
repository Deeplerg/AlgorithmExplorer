using AlgorithmExplorer.Application.ExecutionCoordinators.Kadane;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class KadaneCoordinatorOptionsMapper() :
    CoordinatorOptionsMapperBase<KadaneCoordinatorOptions>(
        expectedType: AlgorithmType.Kadane,
        expectedInputCount: 1)
{
    protected override KadaneCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
        => new(MapBase(inputs).IterationCount);
}

using AlgorithmExplorer.Application.ExecutionCoordinators.Kadane;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class KadaneCoordinatorOptionsMapper() :
    CoordinatorOptionsMapperBase<KadaneCoordinatorOptions>(
        expectedType: AlgorithmType.Kadane,
        expectedInputCount: BaseExpectedInputCount)
{
    protected override KadaneCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
        => MapInherited(new(), inputs);
}

using AlgorithmExplorer.Application.ExecutionCoordinators.LIS;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class LISCoordinatorOptionsMapper() :
    CoordinatorOptionsMapperBase<LISCoordinatorOptions>(
        expectedType: AlgorithmType.LIS,
        expectedInputCount: BaseExpectedInputCount)
{
    protected override LISCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
        => MapInherited(new(), inputs);
}

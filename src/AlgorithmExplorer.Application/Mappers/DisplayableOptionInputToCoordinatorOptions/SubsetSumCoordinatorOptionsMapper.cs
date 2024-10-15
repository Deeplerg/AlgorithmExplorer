using AlgorithmExplorer.Application.ExecutionCoordinators.SubsetSum;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class SubsetSumCoordinatorOptionsMapper() :
    CoordinatorOptionsMapperBase<SubsetSumCoordinatorOptions>(
        expectedType: AlgorithmType.SubsetSum,
        expectedInputCount: BaseExpectedInputCount)
{
    protected override SubsetSumCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
        => MapInherited(new(), inputs);
}

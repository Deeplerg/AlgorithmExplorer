using AlgorithmExplorer.Application.ExecutionCoordinators.TimSort;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class TimSortCoordinatorOptionsMapper() :
    CoordinatorOptionsMapperBase<TimSortCoordinatorOptions>(
        expectedType: AlgorithmType.TimSort,
        expectedInputCount: BaseExpectedInputCount)
{
    protected override TimSortCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
        => MapInherited(new(), inputs);
}

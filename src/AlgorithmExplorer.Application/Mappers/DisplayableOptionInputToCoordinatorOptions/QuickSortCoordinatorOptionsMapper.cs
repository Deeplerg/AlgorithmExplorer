using AlgorithmExplorer.Application.ExecutionCoordinators.QuickSort;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class QuickSortCoordinatorOptionsMapper() :
    CoordinatorOptionsMapperBase<QuickSortCoordinatorOptions>(
        expectedType: AlgorithmType.QuickSort,
        expectedInputCount: BaseExpectedInputCount)
{
    protected override QuickSortCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
        => MapInherited(new(), inputs);
}

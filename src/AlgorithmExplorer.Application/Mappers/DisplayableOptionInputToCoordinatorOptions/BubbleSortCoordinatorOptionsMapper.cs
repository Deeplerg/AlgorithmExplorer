using AlgorithmExplorer.Application.ExecutionCoordinators.BubbleSort;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class BubbleSortCoordinatorOptionsMapper() :
    CoordinatorOptionsMapperBase<BubbleSortCoordinatorOptions>(
        expectedType: AlgorithmType.BubbleSort,
        expectedInputCount: BaseExpectedInputCount)
{
    protected override BubbleSortCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
        => MapInherited(new(), inputs);
}

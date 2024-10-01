using AlgorithmExplorer.Application.ExecutionCoordinators.BitonicSort;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class BitonicSortCoordinatorOptionsMapper() :
    CoordinatorOptionsMapperBase<BitonicSortCoordinatorOptions>(
        expectedType: AlgorithmType.BitonicSort,
        expectedInputCount: 1)
{
    protected override BitonicSortCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
        => new(MapBase(inputs).IterationCount);
}

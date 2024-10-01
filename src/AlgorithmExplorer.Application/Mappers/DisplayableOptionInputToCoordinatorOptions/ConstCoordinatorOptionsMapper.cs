using AlgorithmExplorer.Application.ExecutionCoordinators.Const;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class ConstCoordinatorOptionsMapper() :
    CoordinatorOptionsMapperBase<ConstCoordinatorOptions>(
        expectedType: AlgorithmType.Const,
        expectedInputCount: 1)
{
    protected override ConstCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
        => new(MapBase(inputs).IterationCount);
}

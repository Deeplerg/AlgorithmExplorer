using AlgorithmExplorer.Application.ExecutionCoordinators.Const;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class ConstCoordinatorOptionsMapper() :
    CoordinatorOptionsMapperBase<ConstCoordinatorOptions>(
        expectedType: AlgorithmType.Const,
        expectedInputCount: BaseExpectedInputCount)
{
    protected override ConstCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
        => MapInherited(new(), inputs);
}

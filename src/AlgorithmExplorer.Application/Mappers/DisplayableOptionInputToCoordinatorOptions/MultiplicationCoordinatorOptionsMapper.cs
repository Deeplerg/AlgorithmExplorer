using AlgorithmExplorer.Application.ExecutionCoordinators.Multiplication;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class MultiplicationCoordinatorOptionsMapper() :
    CoordinatorOptionsMapperBase<MultiplicationCoordinatorOptions>(
        expectedType: AlgorithmType.Multiplication,
        expectedInputCount: BaseExpectedInputCount)
{
    protected override MultiplicationCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
        => MapInherited(new(), inputs);
}

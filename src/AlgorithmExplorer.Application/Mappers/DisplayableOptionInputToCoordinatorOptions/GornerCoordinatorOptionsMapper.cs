using AlgorithmExplorer.Application.ExecutionCoordinators.Gorner;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class GornerCoordinatorOptionsMapper() :
    CoordinatorOptionsMapperBase<GornerCoordinatorOptions>(
        expectedType: AlgorithmType.Gorner,
        expectedInputCount: BaseExpectedInputCount)
{
    protected override GornerCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
        => MapInherited(new(), inputs);
}

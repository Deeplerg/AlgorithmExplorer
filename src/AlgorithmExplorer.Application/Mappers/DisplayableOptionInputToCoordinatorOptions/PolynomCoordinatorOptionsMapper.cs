using AlgorithmExplorer.Application.ExecutionCoordinators.Polynom;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class PolynomCoordinatorOptionsMapper() :
    CoordinatorOptionsMapperBase<PolynomCoordinatorOptions>(
        expectedType: AlgorithmType.Polynom,
        expectedInputCount: BaseExpectedInputCount)
{
    protected override PolynomCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
        => MapInherited(new(), inputs);
}

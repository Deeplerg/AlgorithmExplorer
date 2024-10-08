using AlgorithmExplorer.Application.ExecutionCoordinators.SimplePow;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class SimplePowCoordinatorOptionsMapper() :
    PowCoordinatorOptionsMapperBase<SimplePowCoordinatorOptions>(
        expectedType: AlgorithmType.SimplePow,
        expectedInputCount: PowExpectedInputCount)
{
    protected override SimplePowCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
        => MapInherited(new(), inputs);
}

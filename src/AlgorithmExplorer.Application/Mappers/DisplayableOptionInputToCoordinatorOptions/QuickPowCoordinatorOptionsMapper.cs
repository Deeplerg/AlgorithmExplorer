using AlgorithmExplorer.Application.ExecutionCoordinators.QuickPow;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class QuickPowCoordinatorOptionsMapper() :
    PowCoordinatorOptionsMapperBase<QuickPowCoordinatorOptions>(
        expectedType: AlgorithmType.QuickPow,
        expectedInputCount: PowExpectedInputCount)
{
    protected override QuickPowCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
        => MapInherited(new(), inputs);
}

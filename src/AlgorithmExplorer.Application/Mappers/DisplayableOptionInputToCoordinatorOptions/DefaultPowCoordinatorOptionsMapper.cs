using AlgorithmExplorer.Application.ExecutionCoordinators.DefaultPow;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class DefaultPowCoordinatorOptionsMapper() :
    PowCoordinatorOptionsMapperBase<DefaultPowCoordinatorOptions>(
        expectedType: AlgorithmType.DefaultPow,
        expectedInputCount: PowExpectedInputCount)
{
    protected override DefaultPowCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
        => MapInherited(new(), inputs);
}

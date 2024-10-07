using AlgorithmExplorer.Application.ExecutionCoordinators.RecursivePow;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class RecursivePowCoordinatorOptionsMapper() :
    PowCoordinatorOptionsMapperBase<RecursivePowCoordinatorOptions>(
        expectedType: AlgorithmType.RecursivePow,
        expectedInputCount: PowExpectedInputCount)
{
    protected override RecursivePowCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
        => MapInherited(new(), inputs);
}

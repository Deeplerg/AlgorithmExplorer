using AlgorithmExplorer.Application.ExecutionCoordinators.MatrixMultiplication;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class MatrixMultiplicationCoordinatorOptionsMapper() :
    CoordinatorOptionsMapperBase<MatrixMultiplicationCoordinatorOptions>(
        expectedType: AlgorithmType.MatrixMultiplication,
        expectedInputCount: BaseExpectedInputCount)
{
    protected override MatrixMultiplicationCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
        => MapInherited(new(), inputs);
}

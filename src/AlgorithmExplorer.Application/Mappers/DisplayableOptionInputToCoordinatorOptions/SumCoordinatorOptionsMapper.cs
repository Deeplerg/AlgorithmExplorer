using AlgorithmExplorer.Application.ExecutionCoordinators.Sum;
using AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions.Base;
using AlgorithmExplorer.Application.Models.Input;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Mappers.DisplayableOptionInputToCoordinatorOptions;

public class SumCoordinatorOptionsMapper() :
    CoordinatorOptionsMapperBase<SumCoordinatorOptions>(
        expectedType: AlgorithmType.Sum,
        expectedInputCount: 1)
{
    protected override SumCoordinatorOptions Map(IEnumerable<DisplayableOptionInput> inputs)
    {
        var iterationCount = MatchDisplayName(inputs, "iterations");

        return new SumCoordinatorOptions(
            IterationCount: int.Parse(iterationCount.Input));
    }
}


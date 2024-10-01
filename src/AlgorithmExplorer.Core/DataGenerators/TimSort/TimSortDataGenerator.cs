using AlgorithmExplorer.Core.Algorithms.TimSort;
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.TimSort;

public class TimSortDataGenerator : NumberSequenceGenerator<TimSortDataGeneratorOptions, TimSortOptions>
{
    public override TimSortOptions Generate(TimSortDataGeneratorOptions options)
    {
        var numbers = GenerateArray(options.Count);
        return new TimSortOptions(numbers);
    }
}
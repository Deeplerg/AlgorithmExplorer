using AlgorithmExplorer.Core.Algorithms.QuickSort;
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.QuickSortAlgorithm;

public class QuickSortDataGenerator : NumberSequenceGenerator<QuickSortDataGeneratorOptions, QuickSortOptions>
{
    public override QuickSortOptions Generate(QuickSortDataGeneratorOptions options)
    {
        var numbers = GenerateArray(options.Count);
        return new QuickSortOptions(numbers);
    }
}
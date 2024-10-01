using AlgorithmExplorer.Core.Algorithms.BubbleSort;
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.BubbleSort;

public class BubbleSortDataGenerator : NumberSequenceGenerator<BubbleSortDataGeneratorOptions, BubbleSortOptions>
{
    public override BubbleSortOptions Generate(BubbleSortDataGeneratorOptions options)
    {
        var numbers = GenerateList(options.Count);
        return new BubbleSortOptions(numbers);
    }
}
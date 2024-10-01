using AlgorithmExplorer.Core.Algorithms.BitonicSort;
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.BitonicSort;

public class BitonicSortDataGenerator : NumberSequenceGenerator<BitonicSortDataGeneratorOptions, BitonicSortOptions>
{
    public override BitonicSortOptions Generate(BitonicSortDataGeneratorOptions options)
    {
        var numbers = GenerateArray(options.Count);
        return new BitonicSortOptions(numbers);
    }
}
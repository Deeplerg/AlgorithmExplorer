using AlgorithmExplorer.Core.Algorithms.SubsetSum;
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.SubsetSum;

public class SubsetSumDataGenerator : NumberSequenceGenerator<SubsetSumDataGeneratorOptions, SubsetSumOptions>
{
    public override SubsetSumOptions Generate(SubsetSumDataGeneratorOptions options)
    {
        var numbers = GenerateArray(options.Count);
        return new SubsetSumOptions(numbers, options.Count);
    }
}
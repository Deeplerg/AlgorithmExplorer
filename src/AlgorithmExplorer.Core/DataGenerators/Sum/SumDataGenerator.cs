using AlgorithmExplorer.Core.Algorithms.Sum;
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.Sum;

public class SumDataGenerator : NumberSequenceGenerator<SumDataGeneratorOptions, SumOptions>
{
    public override SumOptions Generate(SumDataGeneratorOptions options)
    {
        var numbers = GenerateNumbers(options.Count);
        return new SumOptions(numbers);
    }
}
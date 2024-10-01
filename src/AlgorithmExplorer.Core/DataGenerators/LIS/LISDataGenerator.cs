using AlgorithmExplorer.Core.Algorithms.LIS;
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.LIS;

public class LISDataGenerator : NumberSequenceGenerator<LISDataGeneratorOptions, LISOptions>
{
    public override LISOptions Generate(LISDataGeneratorOptions options)
    {
        var numbers = GenerateArray(options.Count);
        return new LISOptions(numbers);
    }
}
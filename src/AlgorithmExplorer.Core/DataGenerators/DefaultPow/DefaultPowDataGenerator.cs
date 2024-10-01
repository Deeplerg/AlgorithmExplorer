using AlgorithmExplorer.Core.Algorithms.DefaultPow;
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.DefaultPow;

public class DefaultPowDataGenerator : NumberSequenceGenerator<DefaultPowDataGeneratorOptions, DefaultPowOptions>
{
    public override DefaultPowOptions Generate(DefaultPowDataGeneratorOptions options)
    {
        var numbers = GenerateArray(options.Count);
        return new DefaultPowOptions(numbers, options.Number);
    }
}
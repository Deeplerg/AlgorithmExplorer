using AlgorithmExplorer.Core.Algorithms.DefaultPow;
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.DefaultPow;

public class DefaultPowDataGenerator : NumberSequenceGenerator<DefaultPowDataGeneratorOptions, DefaultPowOptions>
{
    public override DefaultPowOptions Generate(DefaultPowDataGeneratorOptions options)
    {
        return new DefaultPowOptions(options.Power, options.Base);
    }
}
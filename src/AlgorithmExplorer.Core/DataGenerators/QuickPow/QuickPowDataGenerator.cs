using AlgorithmExplorer.Core.Algorithms.QuickPow;
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.QuickPow;

public class QuickPowDataGenerator : NumberSequenceGenerator<QuickPowDataGeneratorOptions, QuickPowOptions>
{
    public override QuickPowOptions Generate(QuickPowDataGeneratorOptions options)
    {
        return new QuickPowOptions(options.Power, options.Base);
    }
}
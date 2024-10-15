using AlgorithmExplorer.Core.Algorithms.QuickPow;
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.QuickPow;

public class QuickPowDataGenerator : IDataGenerator<QuickPowDataGeneratorOptions, QuickPowOptions>
{
    public QuickPowOptions Generate(QuickPowDataGeneratorOptions options)
    {
        return new QuickPowOptions(options.Power, options.Base);
    }
}
using AlgorithmExplorer.Core.Algorithms.RecursivePow;
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.RecursivePow;

public class RecursivePowDataGenerator : NumberSequenceGenerator<RecursivePowDataGeneratorOptions, RecursivePowOptions>
{
    public override RecursivePowOptions Generate(RecursivePowDataGeneratorOptions options)
    {
        return new RecursivePowOptions(options.Power, options.Base);
    }
}
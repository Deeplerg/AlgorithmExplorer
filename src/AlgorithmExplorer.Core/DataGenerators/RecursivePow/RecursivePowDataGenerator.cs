using AlgorithmExplorer.Core.Algorithms.RecursivePow;
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.RecursivePow;

public class RecursivePowDataGenerator : IDataGenerator<RecursivePowDataGeneratorOptions, RecursivePowOptions>
{
    public RecursivePowOptions Generate(RecursivePowDataGeneratorOptions options)
    {
        return new RecursivePowOptions(options.Power, options.Base);
    }
}
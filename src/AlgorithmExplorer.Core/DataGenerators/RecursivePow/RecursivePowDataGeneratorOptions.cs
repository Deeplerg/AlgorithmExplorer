using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.RecursivePow;

public class RecursivePowDataGeneratorOptions : PowDataGeneratorOptionsBase
{
    public RecursivePowDataGeneratorOptions()
    {
    }

    public RecursivePowDataGeneratorOptions(int power, int @base) : base(power, @base)
    {
    }
}
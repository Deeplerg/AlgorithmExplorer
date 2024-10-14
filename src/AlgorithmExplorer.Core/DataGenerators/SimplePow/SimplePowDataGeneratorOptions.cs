using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.SimplePow;

public class SimplePowDataGeneratorOptions : PowDataGeneratorOptionsBase
{
    public SimplePowDataGeneratorOptions()
    {
    }

    public SimplePowDataGeneratorOptions(int power, int @base) : base(power, @base)
    {
    }
}
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.DefaultPow;

public class DefaultPowDataGeneratorOptions : PowDataGeneratorOptionsBase
{
    public DefaultPowDataGeneratorOptions()
    {
    }

    public DefaultPowDataGeneratorOptions(int power, int @base) : base(power, @base)
    {
    }
}
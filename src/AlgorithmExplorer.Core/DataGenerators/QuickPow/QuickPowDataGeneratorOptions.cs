using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.QuickPow;

public class QuickPowDataGeneratorOptions : PowDataGeneratorOptionsBase
{
    public QuickPowDataGeneratorOptions()
    {
    }

    public QuickPowDataGeneratorOptions(int power, int @base) : base(power, @base)
    {
    }
}
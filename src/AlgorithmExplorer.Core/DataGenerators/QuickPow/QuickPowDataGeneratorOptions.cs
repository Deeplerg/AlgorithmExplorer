using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.QuickPow;

public class QuickPowDataGeneratorOptions : PowDataGeneratorOptionsBase
{
    public QuickPowDataGeneratorOptions()
    {
    }

    public QuickPowDataGeneratorOptions(int count, int number) : base(count, number)
    {
    }
}
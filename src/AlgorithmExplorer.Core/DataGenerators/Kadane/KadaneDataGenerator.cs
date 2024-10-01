using AlgorithmExplorer.Core.Algorithms.Kadane;
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.Kadane;

public class KadaneDataGenerator : NumberSequenceGenerator<KadaneDataGeneratorOptions, KadaneOptions>
{
    public override KadaneOptions Generate(KadaneDataGeneratorOptions options)
    {
        var numbers = GenerateArray(options.Count);
        return new KadaneOptions(numbers);
    }
}
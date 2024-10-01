using AlgorithmExplorer.Core.Algorithms.Gorner;
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.Gorner;

public class GornerDataGenerator : NumberSequenceGenerator<GornerDataGeneratorOptions, GornerOptions>
{
    public override GornerOptions Generate(GornerDataGeneratorOptions options)
    {
        var numbers = GenerateList(options.Count);
        return new GornerOptions(numbers);
    }
}
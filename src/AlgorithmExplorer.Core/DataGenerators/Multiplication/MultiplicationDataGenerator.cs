using AlgorithmExplorer.Core.Algorithms.Multiplication;
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.Multiplication;

public class MultiplicationDataGenerator : NumberSequenceGenerator<MultiplicationDataGeneratorOptions, MultiplicationOptions>
{
    public override MultiplicationOptions Generate(MultiplicationDataGeneratorOptions options)
    {
        var numbers = GenerateNumbers(options.Count);
        return new MultiplicationOptions(numbers);
    }
}
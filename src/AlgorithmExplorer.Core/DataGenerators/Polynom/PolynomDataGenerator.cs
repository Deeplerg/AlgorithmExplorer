using AlgorithmExplorer.Core.Algorithms.Polynom;
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.Polynom;

public class PolynomDataGenerator : NumberSequenceGenerator<PolynomDataGeneratorOptions, PolynomOptions>
{
    public override PolynomOptions Generate(PolynomDataGeneratorOptions options)
    {
        var numbers = GenerateList(options.Count);
        return new PolynomOptions(numbers);
    }
}
using AlgorithmExplorer.Core.Algorithms.Const;

namespace AlgorithmExplorer.Core.DataGenerators.Const;

public class ConstDataGenerator : IDataGenerator<ConstDataGeneratorOptions, ConstOptions>
{
    public ConstOptions Generate(ConstDataGeneratorOptions options)
    {
        return new ConstOptions();
    }
}
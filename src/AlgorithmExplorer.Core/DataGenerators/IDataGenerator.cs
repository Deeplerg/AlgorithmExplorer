namespace AlgorithmExplorer.Core.DataGenerators;

public interface IDataGenerator<TGenerationOptions, TRunOptions>
{
    TRunOptions Generate(TGenerationOptions options);
}
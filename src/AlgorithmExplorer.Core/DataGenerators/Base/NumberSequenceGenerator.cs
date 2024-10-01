namespace AlgorithmExplorer.Core.DataGenerators.Base;

public abstract class NumberSequenceGenerator<TGenerationOptions, TRunOptions> 
    : IDataGenerator<TGenerationOptions, TRunOptions> 
{
    public abstract TRunOptions Generate(TGenerationOptions options);
    
    protected IEnumerable<int> GenerateNumbers(int sequenceLength)
        => GenerateNumbers(sequenceLength, Random.Shared);
    
    protected IEnumerable<int> GenerateNumbers(int sequenceLength, Random random)
    {
        var array = new int[sequenceLength];
        
        for (int i = 0; i < sequenceLength; i++)
        {
            int number = random.Next();
            array[i] = number;
        }

        return array;
    }
}
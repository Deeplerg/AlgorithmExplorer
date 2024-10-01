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
    
    protected int[] GenerateArray(int sequenceLength)
        => GenerateArray(sequenceLength, Random.Shared);
    
    protected int[] GenerateArray(int sequenceLength, Random random)
    {
        var array = new int[sequenceLength];
        
        for (int i = 0; i < sequenceLength; i++)
        {
            int number = random.Next();
            array[i] = number;
        }

        return array;
    }
    
    protected IList<int> GenerateList(int sequenceLength)
        => GenerateList(sequenceLength, Random.Shared);
    
    protected IList<int> GenerateList(int sequenceLength, Random random)
    {
        var list = new List<int>(sequenceLength);
        
        for (int i = 0; i < sequenceLength; i++)
        {
            int number = random.Next();
            list.Add(number);
        }

        return list;
    }
}
namespace AlgorithmExplorer.Core.DataGenerators.Base;

public class SequenceDataGeneratorOptionsBase
{
    public SequenceDataGeneratorOptionsBase()
    {
    }

    public SequenceDataGeneratorOptionsBase(int count)
    {
        Count = count;
    }

    public int Count { get; set; }

    public void Deconstruct(out int count)
    {
        count = Count;
    }
}
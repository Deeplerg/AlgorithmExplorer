namespace AlgorithmExplorer.Core.DataGenerators.Base;

public class PowDataGeneratorOptionsBase
{
    public PowDataGeneratorOptionsBase()
    {
    }

    public PowDataGeneratorOptionsBase(int count, int number)
    {
        Count = count;
        Number = number;
    }

    public int Count { get; set; }
    public int Number { get; set; }

    public void Deconstruct(out int count)
    {
        count = Count;
    }
}
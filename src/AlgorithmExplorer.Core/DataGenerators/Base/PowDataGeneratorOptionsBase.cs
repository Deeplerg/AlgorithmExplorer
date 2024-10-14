namespace AlgorithmExplorer.Core.DataGenerators.Base;

public class PowDataGeneratorOptionsBase
{
    public PowDataGeneratorOptionsBase()
    {
    }

    public PowDataGeneratorOptionsBase(int power, int @base)
    {
        Power = power;
        Base = @base;
    }

    public int Power { get; set; }
    public int Base { get; set; }

    public void Deconstruct(out int power, out int @base)
    {
        power = Power;
        @base = Base;
    }
}
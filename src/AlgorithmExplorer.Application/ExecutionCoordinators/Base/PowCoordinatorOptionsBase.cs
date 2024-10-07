namespace AlgorithmExplorer.Application.ExecutionCoordinators.Base;

public class PowCoordinatorOptionsBase : CoordinatorOptionsBase
{
    public PowCoordinatorOptionsBase()
    {
    }

    public int Number { get; set; }

    public void Deconstruct(out int iterationCount, out int number)
    {
        iterationCount = IterationCount;
        number = Number;
    }
}
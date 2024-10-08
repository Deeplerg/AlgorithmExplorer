namespace AlgorithmExplorer.Application.ExecutionCoordinators.Base;

public class CoordinatorOptionsBase
{
    public CoordinatorOptionsBase()
    {
    }

    public int IterationCount { get; set; }

    public void Deconstruct(out int iterationCount)
    {
        iterationCount = IterationCount;
    }
}
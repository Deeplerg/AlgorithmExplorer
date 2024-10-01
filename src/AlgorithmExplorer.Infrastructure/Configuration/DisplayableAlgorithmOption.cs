namespace AlgorithmExplorer.Infrastructure.Configuration;

public class DisplayableAlgorithmOption
{
    public AlgorithmType AlgorithmName { get; set; } = AlgorithmType.None;
    public List<DisplayableCoordinatorOption> DisplayableCoordinatorOptions { get; set; } = new();
}
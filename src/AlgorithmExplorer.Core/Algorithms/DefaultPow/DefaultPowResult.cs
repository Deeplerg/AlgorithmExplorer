namespace AlgorithmExplorer.Core.Algorithms.DefaultPow;

public record class DefaultPowResult(
    long Result, 
    long Operations) 
    : OperationsResultBase(Operations);
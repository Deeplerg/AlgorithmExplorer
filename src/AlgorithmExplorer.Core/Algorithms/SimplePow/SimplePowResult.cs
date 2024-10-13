namespace AlgorithmExplorer.Core.Algorithms.SimplePow;

public record class SimplePowResult(
    long Result, 
    long Operations) 
    : OperationsResultBase(Operations);
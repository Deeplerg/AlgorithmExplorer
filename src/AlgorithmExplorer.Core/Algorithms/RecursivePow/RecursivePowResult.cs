namespace AlgorithmExplorer.Core.Algorithms.RecursivePow;

public record class RecursivePowResult(
    long Result, 
    long Operations) 
    : OperationsResultBase(Operations);
namespace AlgorithmExplorer.Core.Algorithms.QuickPow;

public record class QuickPowResult(
    long Result, 
    long Operations) 
    : OperationsResultBase(Operations);
namespace AlgorithmExplorer.Core.Algorithms;

public class CancellableResult<TResult>
{
    public CancellableResult()
    {
    }

    public CancellableResult(TResult result)
    {
        Result = result;
    }

    public bool IsCancelled => Result is null;
    public TResult? Result { get; init; }
    public static CancellableResult<TResult> Empty => new();
}
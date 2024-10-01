namespace AlgorithmExplorer.Core.Algorithms.Sum;

public class SumAlgorithm : ICancellableAlgorithm<SumOptions, SumResult>
{
    public CancellableResult<SumResult> Run(SumOptions options, CancellationToken token)
    {
        var elements = options.Elements;

        int result = 0;
        foreach (int number in elements)
        {
            if (token.IsCancellationRequested)
                return CancellableResult<SumResult>.Empty;

            result += number;
        }

        return new CancellableResult<SumResult>
        {
            Result = new SumResult(result)
        };
    }
}
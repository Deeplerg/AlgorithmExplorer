namespace AlgorithmExplorer.Core.Algorithms.Const;

public class ConstAlgorithm : ICancellableAlgorithm<ConstOptions, ConstResult>
{
    public CancellableResult<ConstResult> Run(ConstOptions options, CancellationToken token)
    {
        if(token.IsCancellationRequested)
            return CancellableResult<ConstResult>.Empty;

        return new CancellableResult<ConstResult>(new ConstResult());
    }
}
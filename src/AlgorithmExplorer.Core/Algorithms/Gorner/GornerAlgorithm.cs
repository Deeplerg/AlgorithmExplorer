namespace AlgorithmExplorer.Core.Algorithms.Gorner;

public class GornerAlgorithm 
    : ICancellableAlgorithm<GornerOptions, GornerResult>
{
    public CancellableResult<GornerResult> Run(GornerOptions options, CancellationToken token)
    {
        long result = 1;
        foreach(int element in options.Elements)
        {
            if(token.IsCancellationRequested)
                return CancellableResult<GornerResult>.Empty;
            
            result *= element;
        }

        return new CancellableResult<GornerResult>(
            new GornerResult(result));
    }
}
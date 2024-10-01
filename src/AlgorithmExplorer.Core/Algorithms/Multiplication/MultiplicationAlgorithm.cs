namespace AlgorithmExplorer.Core.Algorithms.Multiplication;

public class MultiplicationAlgorithm 
    : ICancellableAlgorithm<MultiplicationOptions, MultiplicationResult>
{
    public CancellableResult<MultiplicationResult> Run(MultiplicationOptions options, CancellationToken token)
    {
        long result = 1;
        foreach(int element in options.Elements)
        {
            if(token.IsCancellationRequested)
                return CancellableResult<MultiplicationResult>.Empty;
            
            result *= element;
        }

        return new CancellableResult<MultiplicationResult>(
            new MultiplicationResult(result));
    }
}
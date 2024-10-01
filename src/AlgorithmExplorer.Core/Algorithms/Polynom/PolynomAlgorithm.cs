namespace AlgorithmExplorer.Core.Algorithms.Polynom;

public class PolynomAlgorithm 
    : ICancellableAlgorithm<PolynomOptions, PolynomResult>
{
    public CancellableResult<PolynomResult> Run(PolynomOptions options, CancellationToken token)
    {
        double result = 0;
        for (int i = 0; i < options.Elements.Count; i++)
        {
            if(token.IsCancellationRequested)
                return CancellableResult<PolynomResult>.Empty;
            
            result += options.Elements[i] * Math.Pow(1.5, i - 1);
        }

        return new CancellableResult<PolynomResult>(
            new PolynomResult(result));
    }
}
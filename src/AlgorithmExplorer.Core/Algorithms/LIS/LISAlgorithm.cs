namespace AlgorithmExplorer.Core.Algorithms.LIS;

public class LISAlgorithm 
    : ICancellableAlgorithm<LISOptions, LISResult>
{
    public CancellableResult<LISResult> Run(LISOptions options, CancellationToken token)
    {
        var array = options.Elements;
        
        int length = array.Length;
        int[] lis = new int[length];
        
        for (int i = 0; i < length; i++)
            lis[i] = 1;

        for (int i = 1; i < length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if(token.IsCancellationRequested)
                    return CancellableResult<LISResult>.Empty;
                
                if (array[i] > array[j] && lis[i] < lis[j] + 1)
                    lis[i] = lis[j] + 1;
            }
        }

        int result = lis.Max();

        return new CancellableResult<LISResult>(
            new LISResult(result));
    }
}
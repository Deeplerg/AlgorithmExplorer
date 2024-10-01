namespace AlgorithmExplorer.Core.Algorithms.BubbleSort;

public class BubbleSortAlgorithm 
    : ICancellableAlgorithm<BubbleSortOptions, BubbleSortResult>
{
    public CancellableResult<BubbleSortResult> Run(BubbleSortOptions options, CancellationToken token)
    {
        var list = options.Elements;
        
        int temp;
        for (int i = 0; i < list.Count; i++)
        {
            for(int j = 0; j < list.Count - 1; j++)
            {
                if(token.IsCancellationRequested)
                    return CancellableResult<BubbleSortResult>.Empty;
                
                if (list[j + 1] < list[j])
                {
                    temp = list[j + 1];
                    list[j + 1] = list[j];
                    list[j] = temp;
                }
            }
        }

        return new CancellableResult<BubbleSortResult>(
            new BubbleSortResult(list));
    }
}
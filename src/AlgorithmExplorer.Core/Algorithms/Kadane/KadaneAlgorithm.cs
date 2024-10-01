namespace AlgorithmExplorer.Core.Algorithms.Kadane;

public class KadaneAlgorithm 
    : ICancellableAlgorithm<KadaneOptions, KadaneResult>
{
    public CancellableResult<KadaneResult> Run(KadaneOptions options, CancellationToken token)
    {
        var list = options.Elements;

        int size = list.Length;
        int maxSoFar = int.MinValue;
        int maxEndingHere = 0;

        for (int i = 0; i < size; i++)
        {
            maxEndingHere += list[i];

            if (maxSoFar < maxEndingHere)
            {
                maxSoFar = maxEndingHere;
            }

            if (maxEndingHere < 0)
            {
                maxEndingHere = 0;
            }
        }

        return new CancellableResult<KadaneResult>(
            new KadaneResult(maxSoFar));
    }
}
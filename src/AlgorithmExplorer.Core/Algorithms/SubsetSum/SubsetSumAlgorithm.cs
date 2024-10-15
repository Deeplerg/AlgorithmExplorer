namespace AlgorithmExplorer.Core.Algorithms.SubsetSum;

public class SubsetSumAlgorithm
    : ICancellableAlgorithm<SubsetSumOptions, SubsetSumResult>
{
    public CancellableResult<SubsetSumResult> Run(SubsetSumOptions options, CancellationToken token)
    {
        var array = options.Elements;
        int target = options.TargetSum;

        int n = array.Length;
        bool[,] dp = new bool[n + 1, target + 1];

        for (int i = 0; i <= n; i++)
            dp[i, 0] = true;

        for (int j = 1; j <= target; j++)
            dp[0, j] = false;

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= target; j++)
            {
                if (token.IsCancellationRequested)
                    return CancellableResult<SubsetSumResult>.Empty;

                if (array[i - 1] > j)
                {
                    dp[i, j] = dp[i - 1, j];
                }
                else
                {
                    dp[i, j] = dp[i - 1, j] || dp[i - 1, j - array[i - 1]];
                }
            }
        }

        bool result = dp[n, target];


        return new CancellableResult<SubsetSumResult>(
            new SubsetSumResult(result));
    }
}
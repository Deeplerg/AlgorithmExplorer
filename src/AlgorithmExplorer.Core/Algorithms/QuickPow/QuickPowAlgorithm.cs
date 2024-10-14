namespace AlgorithmExplorer.Core.Algorithms.QuickPow;

public class QuickPowAlgorithm : ICancellableAlgorithm<QuickPowOptions, QuickPowResult>
{
    public CancellableResult<QuickPowResult> Run(QuickPowOptions options, CancellationToken token)
    {
        var power = options.Power;
        var @base = options.Base;

        var (result, operations) = AuxiliaryFunction(@base, power);

        return new CancellableResult<QuickPowResult>
        {
            Result = new QuickPowResult(result, operations)
        };
    }
    
    private static (long, int) AuxiliaryFunction(int @base, int power)
    {
        int temp = @base;
        long result = 1;
        int count = power;
        int operationCount = 0;

        while (count != 0)
        {
            operationCount++;

            if (count % 2 == 0)
            {
                temp *= temp;
                count /= 2;
            }
            else
            {
                result *= temp;
                count--;
            }
        }
        return (result, operationCount);
    }
}
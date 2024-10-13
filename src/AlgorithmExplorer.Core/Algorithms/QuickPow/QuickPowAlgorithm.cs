namespace AlgorithmExplorer.Core.Algorithms.QuickPow;

public class QuickPowAlgorithm : ICancellableAlgorithm<QuickPowOptions, QuickPowResult>
{
    public CancellableResult<QuickPowResult> Run(QuickPowOptions options, CancellationToken token)
    {
        var array = options.Elements;
        var number = options.Number;

        long result = 0;
        int totalOperations = 0;

        for (int i = 0; i < array.Length; i++)
        {
            var (res, operations) = AuxiliaryFunction(number, array[i]);
            result = res;
            totalOperations += operations;
        }

        return new CancellableResult<QuickPowResult>
        {
            Result = new QuickPowResult(result, totalOperations) 
        };
    }
    
    private static (long, int) AuxiliaryFunction(int number, int degree)
    {
        int temp = number;
        long result = 1;
        int count = degree;
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
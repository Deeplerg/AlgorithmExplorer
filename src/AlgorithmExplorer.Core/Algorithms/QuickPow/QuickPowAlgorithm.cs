namespace AlgorithmExplorer.Core.Algorithms.QuickPow;

public class QuickPowAlgorithm : ICancellableAlgorithm<QuickPowOptions, QuickPowResult>
{
    public CancellableResult<QuickPowResult> Run(QuickPowOptions options, CancellationToken token)
    {
        var array = options.Elements;
        var number = options.Number;

        long result = 0;
        for (int i = 0; i < array.Length; i++)
        {
            result = AuxiliaryFunction(number, array[i]);
        }

        return new CancellableResult<QuickPowResult>
        {
            Result = new QuickPowResult(result)
        };
    }
    
    private static long AuxiliaryFunction(int number, int degree)
    {
        int temp = number;
        long result = 1;
        int count = degree;
        while(count != 0)
        {
            if(count % 2 == 0)
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
        return result;
    }

}
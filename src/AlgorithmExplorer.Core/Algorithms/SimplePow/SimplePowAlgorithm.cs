using AlgorithmExplorer.Core.Algorithms.DefaultPow;

namespace AlgorithmExplorer.Core.Algorithms.SimplePow;

public class SimplePowAlgorithm : ICancellableAlgorithm<SimplePowOptions, SimplePowResult>
{
    public CancellableResult<SimplePowResult> Run(SimplePowOptions options, CancellationToken token)
    {
        var array = options.Elements;
        var number = options.Number;

        long result = 0;
        for (int i = 0; i < array.Length; i++)
        {
            result = AuxiliaryFunction(number, array[i]);
        }

        return new CancellableResult<SimplePowResult>
        {
            Result = new SimplePowResult(result)
        };
    }
    private static long AuxiliaryFunction(int degree, int number)
    {
        var count = 0;
        var result = 1;
        while (count < degree)
        {
            result *= number;
            count++;
        }

        return result;
    }

}
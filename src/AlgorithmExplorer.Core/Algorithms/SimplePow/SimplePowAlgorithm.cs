using AlgorithmExplorer.Core.Algorithms.DefaultPow;

namespace AlgorithmExplorer.Core.Algorithms.SimplePow;

public class SimplePowAlgorithm : ICancellableAlgorithm<SimplePowOptions, SimplePowResult>
{
    public CancellableResult<SimplePowResult> Run(SimplePowOptions options, CancellationToken token)
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

        return new CancellableResult<SimplePowResult>
        {
            Result = new SimplePowResult(result, totalOperations)
        };
    }

    private static (long, int) AuxiliaryFunction(int degree, int number)
    {
        var count = 0;
        var result = 1;
        var operations = 0;

        while (count < degree)
        {
            result *= number;
            operations++;
            count++;
        }

        return (result, operations);
    }

}
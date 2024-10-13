namespace AlgorithmExplorer.Core.Algorithms.DefaultPow;

public class DefaultPowAlgorithm : ICancellableAlgorithm<DefaultPowOptions, DefaultPowResult>
{
    public CancellableResult<DefaultPowResult> Run(DefaultPowOptions options, CancellationToken token)
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

        return new CancellableResult<DefaultPowResult>
        {
            Result = new DefaultPowResult(result, totalOperations)
        };
    }

    private static (long, int) AuxiliaryFunction(int degree, int number)
    {
        if (degree == 0)
        {
            return (1, 0);
        }
        else
        {
            var (partialResult, partialOps) = AuxiliaryFunction(number, degree - 1);
            // Each recursive call with multiplication counts as an operation
            return (number * partialResult, partialOps + 1);
        }
    }
}
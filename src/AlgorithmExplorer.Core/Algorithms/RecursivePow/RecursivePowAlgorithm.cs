namespace AlgorithmExplorer.Core.Algorithms.RecursivePow;

public class RecursivePowAlgorithm : ICancellableAlgorithm<RecursivePowOptions, RecursivePowResult>
{
    public CancellableResult<RecursivePowResult> Run(RecursivePowOptions options, CancellationToken token)
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
        
        return new CancellableResult<RecursivePowResult>
        {
            Result = new RecursivePowResult(result, totalOperations)
        };
    }
    
    private static (long, int) AuxiliaryFunction(int number, int degree)
    {
        if (degree == 0)
        {
            return (1, 1);
        }

        int operationCount = 1; // Counting the call itself

        var (result, recursiveOps) = AuxiliaryFunction(number, degree / 2);
        operationCount += recursiveOps; // Add recursive operation count

        if (degree % 2 == 1)
        {
            result = result * result * number;
            operationCount += 2;  // 2 multiplications
        }
        else
        {
            result = result * result;
            operationCount += 1; // 1 multiplication
        }

        return (result, operationCount);
    }
}
namespace AlgorithmExplorer.Core.Algorithms.RecursivePow;

public class RecursivePowAlgorithm : ICancellableAlgorithm<RecursivePowOptions, RecursivePowResult>
{
    public CancellableResult<RecursivePowResult> Run(RecursivePowOptions options, CancellationToken token)
    {
        var power = options.Power;
        var @base = options.Base;

        var (result, operations) = AuxiliaryFunction(@base, power);
        
        return new CancellableResult<RecursivePowResult>
        {
            Result = new RecursivePowResult(result, operations)
        };
    }
    
    private static (long, int) AuxiliaryFunction(int @base, int power)
    {
        if (power == 0)
        {
            return (1, 1);
        }

        int operationCount = 1; // Counting the call itself

        var (result, recursiveOps) = AuxiliaryFunction(@base, power / 2);
        operationCount += recursiveOps; // Add recursive operation count

        if (power % 2 == 1)
        {
            result = result * result * @base;
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
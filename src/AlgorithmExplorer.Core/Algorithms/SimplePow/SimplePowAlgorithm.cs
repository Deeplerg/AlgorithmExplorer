using AlgorithmExplorer.Core.Algorithms.DefaultPow;

namespace AlgorithmExplorer.Core.Algorithms.SimplePow;

public class SimplePowAlgorithm : ICancellableAlgorithm<SimplePowOptions, SimplePowResult>
{
    public CancellableResult<SimplePowResult> Run(SimplePowOptions options, CancellationToken token)
    {
        var power = options.Power;
        var @base = options.Base;

        var (result, operations) = AuxiliaryFunction(@base, power);

        return new CancellableResult<SimplePowResult>
        {
            Result = new SimplePowResult(result, operations)
        };
    }

    private static (long, int) AuxiliaryFunction(int @base, int power)
    {
        var count = 0;
        var result = 1;
        var operations = 0;

        while (count < power)
        {
            result *= @base;
            operations++;
            count++;
        }

        return (result, operations);
    }

}
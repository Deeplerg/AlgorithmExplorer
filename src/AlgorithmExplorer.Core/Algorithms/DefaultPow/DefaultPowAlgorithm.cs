namespace AlgorithmExplorer.Core.Algorithms.DefaultPow;

public class DefaultPowAlgorithm : ICancellableAlgorithm<DefaultPowOptions, DefaultPowResult>
{
    public CancellableResult<DefaultPowResult> Run(DefaultPowOptions options, CancellationToken token)
    {
        var power = options.Power;
        var @base = options.Base;

        var (result, operations) = AuxiliaryFunction(@base, power);

        return new CancellableResult<DefaultPowResult>
        {
            Result = new DefaultPowResult(result, operations)
        };
    }

    private static (long, long) AuxiliaryFunction(int @base, int power)
    {
        if (power == 0)
        {
            return (1, 0);
        }
        else
        {
            var (partialResult, operations) = AuxiliaryFunction(@base, power - 1);
            // Each recursive call with multiplication counts as an operation
            return (@base * partialResult, operations + 1);
        }
    }
}
namespace AlgorithmExplorer.Core.Algorithms.DefaultPow;

public class DefaultPowAlgorithm : ICancellableAlgorithm<DefaultPowOptions, DefaultPowResult>
{
    public CancellableResult<DefaultPowResult> Run(DefaultPowOptions options, CancellationToken token)
    {
        var array = options.Elements;
        var number = options.Number;

        long result = 0;
        for (int i = 0; i < array.Length; i++)
        {
            result = AuxiliaryFunction(number, array[i]);
        }

        return new CancellableResult<DefaultPowResult>
        {
            Result = new DefaultPowResult(result)
        };
    }
    private static long AuxiliaryFunction(int degree, int number)
    {
        if (degree < 0)
        {
            throw new ArgumentException("Degree cannot be negative");
        }

        long result = 1;
        for (int i = 0; i < degree; i++)
        {
            result *= number;
        }

        return result;
    }

}
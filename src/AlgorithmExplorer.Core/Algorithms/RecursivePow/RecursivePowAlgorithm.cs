namespace AlgorithmExplorer.Core.Algorithms.RecursivePow;

public class RecursivePowAlgorithm : ICancellableAlgorithm<RecursivePowOptions, RecursivePowResult>
{
    public CancellableResult<RecursivePowResult> Run(RecursivePowOptions options, CancellationToken token)
    {
        var array = options.Elements;
        var number = options.Number;

        long result = 0;
        for (int i = 0; i < array.Length; i++)
        {
            result = AuxiliaryFunction(number, array[i]);
        }

        return new CancellableResult<RecursivePowResult>
        {
            Result = new RecursivePowResult(result)
        };
    }
    
    private static long AuxiliaryFunction(int number, int degree)
    {
        long result;
        if(degree == 0)
        {
            return 1;
        }
        else
        {
            result = AuxiliaryFunction(number, degree / 2);
            if(degree % 2 == 1)
            {
                result = result * result * number;
            }
            else
            {
                result = result * result;
            }
        }
        return result;
    }

}
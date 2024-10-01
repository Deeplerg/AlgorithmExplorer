namespace AlgorithmExplorer.Core.Algorithms.QuickSort;

public class QuickSortAlgorithm 
    : ICancellableAlgorithm<QuickSortOptions, QuickSortResult>
{
    public CancellableResult<QuickSortResult> Run(QuickSortOptions options, CancellationToken token)
    {
        var list = options.Elements;

        Function(list, 0, list.Length - 1);
        
        return new CancellableResult<QuickSortResult>(
            new QuickSortResult(list));
    }
    
    public static void Function(int[] vector, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(vector, low, high);
            Function(vector, low, pivotIndex - 1);
            Function(vector, pivotIndex + 1, high);
        }
    }

    private static int Partition(int[] vector, int low, int high)
    {
        int pivot = vector[(low + high) / 2];
        int i = low - 1;
        int j = high + 1;
        while (true)
        {
            do
            {
                i++;
            } while (vector[i] < pivot);

            do
            {
                j--;
            } while (vector[j] > pivot);

            if (i >= j)
                return j;

            Swap(vector, i, j);
        }
    }

    private static void Swap(int[] vector, int index1, int index2)
    {
        int temp = vector[index1];
        vector[index1] = vector[index2];
        vector[index2] = temp;
    }
}
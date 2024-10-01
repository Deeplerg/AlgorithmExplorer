namespace AlgorithmExplorer.Core.Algorithms.TimSort;

public class TimSortAlgorithm 
    : ICancellableAlgorithm<TimSortOptions, TimSortResult>
{
    public CancellableResult<TimSortResult> Run(TimSortOptions options, CancellationToken token)
    {
        var array = options.Elements;

        if(token.IsCancellationRequested)
            return CancellableResult<TimSortResult>.Empty;
        
        Function(array, array.Length);

        return new CancellableResult<TimSortResult>(
            new TimSortResult(array));
    }
    
    public static void Function(int[] vector, int n)
    {
        for (int i = 0; i < n; i += RUN)
            insertionSort(vector, i, Math.Min((i + RUN - 1), (n - 1)));

        for (int size = RUN; size < n; size = 2 * size)
        {

            for (int left = 0; left < n; left += 2 * size)
            {

                int mid = left + size - 1;
                int right = Math.Min((left + 2 * size - 1),
                    (n - 1));

                if (mid < right)
                    merge(vector, left, mid, right);
            }
        }
    }

    private const int RUN = 32;

    private static void insertionSort(int[] vector, int left, int right)        
    {
        for (int i = left + 1; i <= right; i++)
        {
            int temp = vector[i];
            int j = i - 1;
            while (j >= left && vector[j] > temp)
            {
                vector[j + 1] = vector[j];
                j--;
            }
            vector[j + 1] = temp;
        }
    }

    private static void merge(int[] vector, int l, int m, int r)
    {
        int len1 = m - l + 1, len2 = r - m;
        int[] left = new int[len1];
        int[] right = new int[len2];
        for (int x = 0; x < len1; x++)
            left[x] = vector[l + x];
        for (int x = 0; x < len2; x++)
            right[x] = vector[m + 1 + x];

        int i = 0;
        int j = 0;
        int k = l;

        while (i < len1 && j < len2)
        {
            if (left[i] <= right[j])
            {
                vector[k] = left[i];
                i++;
            }
            else
            {
                vector[k] = right[j];
                j++;
            }
            k++;
        }

        while (i < len1)
        {
            vector[k] = left[i];
            k++;
            i++;
        }

        while (j < len2)
        {
            vector[k] = right[j];
            k++;
            j++;
        }
    }

}
namespace AlgorithmExplorer.Core.Algorithms.BitonicSort;

public class BitonicSortAlgorithm 
    : ICancellableAlgorithm<BitonicSortOptions, BitonicSortResult>
{
    public CancellableResult<BitonicSortResult> Run(BitonicSortOptions options, CancellationToken token)
    {
        var array = options.Elements;

        if(token.IsCancellationRequested)
            return CancellableResult<BitonicSortResult>.Empty;
        
        array = Sort(array);
        
        return new CancellableResult<BitonicSortResult>(
            new BitonicSortResult(array));
    }
    
    public int[] Sort(int[] array, bool ascending = true)
    {
        var cloneArray = (int[])array.Clone();
        var n = cloneArray.Length;

        if (n > 0 && (n & (n - 1)) != 0) throw new ArgumentException("Размер массива должен быть степенью двойки");
        
        BitonicSortRecursive(cloneArray, 0, n, ascending);

        return cloneArray;
    }

    private void BitonicSortRecursive(int[] array, int low, int cnt, bool ascending)
    {
        if (cnt > 1)
        {
            var k = cnt / 2;

            BitonicSortRecursive(array, low, k, true);
            BitonicSortRecursive(array, low + k, k, false);

            BitonicMerge(array, low, cnt, ascending);
        }
    }

    private void BitonicMerge(int[] array, int low, int cnt, bool ascending)
    {
        if (cnt > 1)
        {
            var k = cnt / 2;

            for (var i = low; i < low + k; i++) CompareAndSwap(array, i, i + k, ascending);

            BitonicMerge(array, low, k, ascending);
            BitonicMerge(array, low + k, k, ascending);
        }
    }

    private void CompareAndSwap(int[] array, int i, int j, bool ascending)
    {
        if (ascending)
        {
            if (array[i] > array[j]) Swap(array, i, j);
        }
        else
        {
            if (array[i] < array[j]) Swap(array, i, j);
        }
    }

    private void Swap(int[] array, int i, int j)
    {
        (array[i], array[j]) = (array[j], array[i]);
    }
}
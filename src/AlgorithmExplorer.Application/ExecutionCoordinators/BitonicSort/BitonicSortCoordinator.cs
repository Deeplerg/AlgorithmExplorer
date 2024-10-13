using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Algorithms.BitonicSort;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.BitonicSort;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.BitonicSort;

public class BitonicSortCoordinator(
    IDataGenerator<BitonicSortDataGeneratorOptions, BitonicSortOptions> generator,
    ICancellableAlgorithm<BitonicSortOptions, BitonicSortResult> algorithm,
    ITimeAlgorithmRunner runner)
    : TimeCoordinatorBase<
        BitonicSortCoordinatorOptions, 
        BitonicSortOptions, 
        BitonicSortResult, 
        BitonicSortDataGeneratorOptions>(
        generator, algorithm, runner)
{
    protected override BitonicSortDataGeneratorOptions ConstructGeneratorOptions(
        BitonicSortCoordinatorOptions options,
        int currentIteration)
        => new() { Count = FindClosestPowerOfTwo(currentIteration) };
    
    static int FindClosestPowerOfTwo(int value)
    {
        int low = (int)Math.Floor(Math.Pow(2, Math.Floor(Math.Log(value) / Math.Log(2))));
        int high = (int)Math.Ceiling(Math.Pow(2, Math.Ceiling(Math.Log(value) / Math.Log(2))));

        if (value - low < high - value)
            return low;
        else
            return high;
    }
}
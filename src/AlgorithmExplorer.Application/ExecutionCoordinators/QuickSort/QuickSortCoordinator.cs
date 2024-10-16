﻿using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Algorithms.QuickSort;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.Benchmarking.Time;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.QuickSort;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.QuickSort;

public class QuickSortCoordinator(
    IDataGenerator<QuickSortDataGeneratorOptions, QuickSortOptions> generator,
    ICancellableAlgorithm<QuickSortOptions, QuickSortResult> algorithm,
    ITimeAlgorithmRunner runner)
    : SequenceCoordinatorBase<
        QuickSortCoordinatorOptions, QuickSortOptions, QuickSortResult, QuickSortDataGeneratorOptions>(generator, algorithm, runner)
{
    protected override QuickSortDataGeneratorOptions ConstructGeneratorOptions(
        QuickSortCoordinatorOptions options,
        int currentIteration)
        => ConstructInheritedGeneratorOptions(new(), options, currentIteration);
}
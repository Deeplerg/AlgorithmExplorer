﻿using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Core.Algorithms;
using AlgorithmExplorer.Core.Algorithms.RecursivePow;
using AlgorithmExplorer.Core.Benchmarking;
using AlgorithmExplorer.Core.DataGenerators;
using AlgorithmExplorer.Core.DataGenerators.RecursivePow;

namespace AlgorithmExplorer.Application.ExecutionCoordinators.RecursivePow;

public class RecursivePowCoordinator(
    IDataGenerator<RecursivePowDataGeneratorOptions, RecursivePowOptions> generator,
    ICancellableAlgorithm<RecursivePowOptions, RecursivePowResult> algorithm,
    ICancellableAlgorithmRunner runner)
    : CoordinatorBase<
        RecursivePowCoordinatorOptions, RecursivePowOptions, RecursivePowResult, RecursivePowDataGeneratorOptions>(generator, algorithm, runner)
{
    protected override RecursivePowDataGeneratorOptions ConstructGeneratorOptions(
        RecursivePowCoordinatorOptions options,
        int currentIteration)
        => new(currentIteration, options.Number);
}
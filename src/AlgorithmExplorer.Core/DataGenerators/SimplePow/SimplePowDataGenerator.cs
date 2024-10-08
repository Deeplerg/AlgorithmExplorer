﻿using AlgorithmExplorer.Core.Algorithms.DefaultPow;
using AlgorithmExplorer.Core.Algorithms.SimplePow;
using AlgorithmExplorer.Core.DataGenerators.Base;

namespace AlgorithmExplorer.Core.DataGenerators.SimplePow;

public class SimplePowDataGenerator : NumberSequenceGenerator<SimplePowDataGeneratorOptions, SimplePowOptions>
{
    public override SimplePowOptions Generate(SimplePowDataGeneratorOptions options)
    {
        var numbers = GenerateArray(options.Count);
        return new SimplePowOptions(numbers, options.Number);
    }
}
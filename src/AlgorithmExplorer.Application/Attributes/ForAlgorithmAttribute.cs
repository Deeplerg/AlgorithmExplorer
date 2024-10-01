using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ForAlgorithmAttribute : Attribute
{
    public AlgorithmType Algorithm { get; }

    public ForAlgorithmAttribute(AlgorithmType algorithm)
    {
        Algorithm = algorithm;
    }
}
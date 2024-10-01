using System.Reflection;
using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.InputExecutors;
using AlgorithmExplorer.Infrastructure.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlgorithmExplorer.Application.Providers.InputExecutors;

public class InputExecutorProvider : IInputExecutorProvider
{
    private readonly List<object> _instances = new();
    
    public InputExecutorProvider(
        IInputExecutorTypeCollection types,
        IServiceProvider serviceProvider)
    {
        var activatedInstances = ActivateInstances(types.GetAll(), serviceProvider);
        _instances.AddRange(activatedInstances);
    }
    
    public IEnumerable<object> GetAll()
    {
        return _instances;
    }

    public IInputExecutor? GetByAlgorithm(AlgorithmType algorithm)
    {
        return (IInputExecutor?)_instances.FirstOrDefault(t => InputExecutorForAlgorithmFilter(t, algorithm));
    }

    public object GetByType(Type type)
    {
        return _instances.First(t => t.GetType() == type);
    }
    
    private IEnumerable<object> ActivateInstances(IEnumerable<Type> inputExecutorTypes, IServiceProvider serviceProvider)
    {
        foreach (var type in inputExecutorTypes)
        {
            yield return ActivatorUtilities.GetServiceOrCreateInstance(serviceProvider, type);
        }
    }

    private bool InputExecutorForAlgorithmFilter(object instance, AlgorithmType algorithmType)
    {
        var type = instance.GetType();

        var attribute = type.GetCustomAttribute<ForAlgorithmAttribute>(inherit: true);

        if (attribute is null)
            return false;
        
        return attribute.Algorithm == algorithmType;
    }
}
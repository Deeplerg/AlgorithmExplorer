using System.Reflection;
using AlgorithmExplorer.Application.Attributes;
using AlgorithmExplorer.Application.InputExecutors;

namespace AlgorithmExplorer.Application.Providers.InputExecutors;

public class InputExecutorTypeCollection : IInputExecutorTypeCollection
{
    private List<Type> types = new();
    
    public void Add(Type type)
    {
        if (!ImplementsInterface(type, typeof(IInputExecutor)))
            throw new ArgumentException($"{type} doesn't implement {nameof(IInputExecutor)}");
        
        types.Add(type);
    }

    public void AddAllFromAssembly(Assembly assembly)
    {
        var fromAssembly = assembly
            .GetTypes()
            .Where(t => ImplementsInterface(t, typeof(IInputExecutor)))
            .Where(t => t.GetCustomAttribute<ForAlgorithmAttribute>() is not null);
        
        types.AddRange(fromAssembly);
    }

    public void Clear()
    {
        types.Clear();
    }

    public IEnumerable<Type> GetAll()
    {
        return types;
    }

    private bool ImplementsInterface(Type type, Type interfaceType)
    {
        return type.GetInterfaces().Any(t => t == interfaceType);
    }
}
using System.Reflection;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Providers.InputExecutors;

public interface IInputExecutorTypeCollection
{
    void Add(Type type);
    
    void AddAllFromAssembly(Assembly assembly);
    
    void Clear();
    
    IEnumerable<Type> GetAll();
}
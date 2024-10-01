using AlgorithmExplorer.Application.InputExecutors;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Providers.InputExecutors;

public interface IInputExecutorProvider
{
    IEnumerable<object> GetAll();
    IInputExecutor? GetByAlgorithm(AlgorithmType algorithm);
    object GetByType(Type type);
}
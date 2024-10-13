using AlgorithmExplorer.Application.InputExecutors;
using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Providers.InputExecutors;

public interface IInputExecutorProvider
{
    IEnumerable<object> GetAll();
    IInputExecutor<TResult>? GetByAlgorithm<TResult>(AlgorithmType algorithm);
    object GetByType(Type type);
}
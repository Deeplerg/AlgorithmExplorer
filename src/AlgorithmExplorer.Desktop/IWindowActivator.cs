using System.Windows;

namespace AlgorithmExplorer.Desktop;

public interface IWindowActivator
{
    
    T CreateInstance<T>() where T : Window;
}
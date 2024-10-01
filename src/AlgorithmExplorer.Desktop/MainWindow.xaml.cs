using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AlgorithmExplorer.Desktop;
using AlgorithmExplorer;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Wpf;
using Microsoft.VisualBasic;
using AlgorithmExplorer.Infrastructure.Configuration;
using System.Configuration;
using AlgorithmExplorer.Application.Providers.InputExecutors;

namespace AlgorithmExplorer.Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private IInputExecutorProvider Provides;

    private CancellationTokenSource cts = new();

    public MainWindow(IInputExecutorProvider input)
    {
        InitializeComponent();

        Provides = input;

        var algorithmNames = Enum.GetNames<AlgorithmType>();
        AlgListBox.Items.Clear();

        string noneName = Enum.GetName(AlgorithmType.None);

        foreach (String alg in algorithmNames)
        {
            if (alg == noneName) continue;
            AlgListBox.Items.Add(alg);
        }

    }

    private async void StartButton_Click(object sender, RoutedEventArgs e)
    {
        string alg = AlgListBox.SelectedItem as string;
        AlgorithmType algorithmType = Enum.Parse<AlgorithmType>(alg, ignoreCase: true);

        MainViewModel model = new MainViewModel();

        model.GetGraphik(InputLength.Text, algorithmType, InputNOR.Text, Provides, cts.Token, InputForPow.Text);
        MainPlot.Model = model.MyModel;
    }

    private void ListViewItem_Selected(object sender, RoutedEventArgs e)
    {

    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        cts.Cancel();
    }
}
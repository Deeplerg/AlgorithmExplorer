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
using AlgorithmExplorer.Application.ExecutionCoordinators.Base;
using AlgorithmExplorer.Core.Benchmarking;

namespace AlgorithmExplorer.Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private IInputExecutorProvider Provides;

    private CancellationTokenSource cts = new();

    private Progress<BenchmarkProgressReport> _progress = new Progress<BenchmarkProgressReport>();

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

        var stepTypes = Enum.GetNames<StepType>();

        foreach(String stepType in stepTypes)
        {
            LtBxSteps.Items.Add(stepType);
        }

        TxBxApr.Text = "3";
        ProgressLabel.Content = string.Empty;

        _progress.ProgressChanged += (sender, report) =>
        {
            ProgressLabel.Content = $"{report.RunsCompleted}/{report.TotalRuns}";

            if ((int)AlgorithmProgressBar.Maximum != report.TotalRuns)
                AlgorithmProgressBar.Maximum = report.TotalRuns;
            AlgorithmProgressBar.Value = report.RunsCompleted;
        };
    }

    private async void StartButton_Click(object sender, RoutedEventArgs e)
    {
        string alg = "";
        string stepType = "";
        AlgorithmType algorithmType = new AlgorithmType();
        if (LtBxSteps.SelectedItem != null)
        {
            stepType = LtBxSteps.SelectedItem.ToString();
        }
        else
        {
            MessageBox.Show("Выберите тип шага");
            return;
        }
        if (!(AlgListBox.SelectedItem == null))
        {
            alg = AlgListBox.SelectedItem as string;
            algorithmType = Enum.Parse<AlgorithmType>(alg, ignoreCase: true);
        }
        else
        {
            MessageBox.Show("Выберите алгоритм");
            return;
        }
        MainViewModel model = new MainViewModel();

        if (int.TryParse(InputLength.Text, out int length) && int.TryParse(InputNOR.Text, out int nOR)
            && int.TryParse(TxBxApr.Text, out int approximationPower)
            && int.TryParse(TxBxStep.Text, out int step)
            && !(alg.Contains("Pow") && !int.TryParse(InputForPow.Text, out int dA)))
        {
            cts = new();
            await model.GetGraphik(
                InputLength.Text,
                algorithmType,
                InputNOR.Text,
                Provides, cts.Token,
                InputForPow.Text,
                TxBxStep.Text,
                stepType,
                TxBxApr.Text,
                _progress);
            MainPlot.Model = model.MyModel;

            TxBlApr.Text = model.aprPolin.ToString();
            TxBlDeviation.Text = model.deviation.ToString();
        }
        else
        {
            MessageBox.Show("Некорректные входные данные");
            return;
        }
    }

    private void ListViewItem_Selected(object sender, RoutedEventArgs e)
    {

    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        cts.Cancel();
    }
}
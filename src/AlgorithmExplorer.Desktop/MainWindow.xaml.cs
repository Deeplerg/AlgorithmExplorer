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

namespace AlgorithmExplorer.Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        MainViewModel model = new MainViewModel();
        MainPlot.Model = model.GetModel(model.MyModel);
    }

    private void ListViewItem_Selected(object sender, RoutedEventArgs e)
    {

    }
}
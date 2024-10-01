using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Series;
using AlgorithmExplorer.Desktop;
using OxyPlot.Wpf;

namespace AlgorithmExplorer.Desktop
{
    public class MainViewModel
    {
        public PlotModel MyModel { get; private set; }

        public PlotModel GetModel(PlotModel model)
        {
            LineSeries series = new LineSeries();
            for (int i = 0; i < Points.Count; i++)
            {
                series.Points.Add(Points[i]);
            }
            model.Series.Add(series);
            return model;
        }

        public IList<DataPoint> Points { get; private set; }

        public MainViewModel()
        {
            MyModel = new PlotModel();
        }
    }
}

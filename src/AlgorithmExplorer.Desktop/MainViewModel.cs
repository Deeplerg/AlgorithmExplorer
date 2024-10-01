using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Series;
using AlgorithmExplorer.Desktop;
using OxyPlot.Wpf;
using AlgorithmExplorer.Infrastructure.Configuration;
using AlgorithmExplorer.Application.Providers.InputExecutors;
using System.Security.Cryptography;
using AlgorithmExplorer.Application.Models.Input;
using System.Windows;
using System.Runtime;

namespace AlgorithmExplorer.Desktop
{
    public class MainViewModel
    {
        public PlotModel MyModel { get; private set; }

        public async Task GetGraphik( string vectorLength, AlgorithmType alg, string count, IInputExecutorProvider inputData, CancellationToken token)
        {
            List<List<Core.Benchmarking.AlgorithmRunResult>> mainList = new();
            for (int k = 0; k < int.Parse(count); k++)
            {

                var executor = inputData.GetByAlgorithm(alg)!;

                var coordinatorOption = new DisplayableCoordinatorOption { DisplayName = "iterations" };
                var optionInput = new DisplayableOptionInput(coordinatorOption, vectorLength);
                var inputOptions = new List<DisplayableOptionInput> { optionInput };
                var inputs = new DisplayableOptionInputs(alg, inputOptions);

                executor.SetInput(inputs);

                var validationResult = executor.ValidateInput();
                /*
                            if (!validationResult.IsValid)
                            {
                                MessageBox.Show(validationResult.Errors);
                            }
                */
                bool prepared = await executor.PrepareDataAsync(token);

                /*
                if (!prepared)
                {
                    MessageBox.Show(...);
                }
    */

                var benchmarkResult = await executor.RunAsync(token);

                mainList[k] = benchmarkResult.AlgorithmResults.ToList();
/*
                LineSeries lineSeries = new LineSeries();
                for (int i = 1; i < int.Parse(vectorLength); i++)
                {
                    lineSeries.Points.Add(new DataPoint(i, list[i].TimeElapsed.TotalMilliseconds));
                }
*/
            }

            List<double> list = new(int.Parse(vectorLength));
            for(int k = 0;k < int.Parse(vectorLength); k++)
            {
                for(int i = 0; i < int.Parse(count); i++)
                {
                    list[k] += mainList[i][k].TimeElapsed.TotalMilliseconds;
                }
            }
            LineSeries lineSeries = new LineSeries();

            for (int k = 0; k < list.Count(); k++)
            {
                lineSeries.Points.Add(new DataPoint(k, list[k] / int.Parse(count)));
            }
            MyModel.Series.Add(lineSeries);
        }

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

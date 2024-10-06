using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using OxyPlot;
using OxyPlot.Series;
using AlgorithmExplorer.Application.Providers.InputExecutors;
using AlgorithmExplorer.Infrastructure.Configuration;
using AlgorithmExplorer.Application.Models.Input;
using OxyPlot.Axes;
using System.Text;

namespace AlgorithmExplorer.Desktop
{
    public class MainViewModel
    {
        public PlotModel MyModel { get; private set; }
        public IList<double> Points { get; private set; }
        public StringBuilder aprPolin {  get; private set; }

        public MainViewModel()
        {
            MyModel = new PlotModel { Title = "График производительности алгоритма" };
            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Размер вектора" });
            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Время (мс)" });
            Points = new List<double>();
        }

        public async Task GetGraphik(string vectorLength, AlgorithmType alg, string count, IInputExecutorProvider inputData, CancellationToken token, string inpForPow)
        {
            List<List<Core.Benchmarking.AlgorithmRunResult>> mainList = new();
            int vectorLen = int.Parse(vectorLength);
            int runCount = int.Parse(count);

            for (int k = 0; k < runCount; k++)
            {
                var executor = inputData.GetByAlgorithm(alg)!;
                var powOptionInput = new DisplayableOptionInput(new DisplayableCoordinatorOption { DisplayName = "number" }, inpForPow);
                var optionInput = new DisplayableOptionInput(new DisplayableCoordinatorOption { DisplayName = "iterations" }, vectorLength);
                var inputs = new DisplayableOptionInputs(alg, new List<DisplayableOptionInput> { optionInput });
                if(alg is AlgorithmType.DefaultPow || alg is AlgorithmType.QuickPow || alg is AlgorithmType.RecursivePow || alg is AlgorithmType.SimplePow)
                {
                    inputs.Inputs.Add(powOptionInput);
                }
                executor.SetInput(inputs);
                var validationResult = executor.ValidateInput();
                if (!validationResult.IsValid)
                {
                    string message = "Ошибка ввода данных!\n";
                    foreach (var error in validationResult.Errors)
                    {
                        message += error.ErrorMessage + "\n";
                    }
                    MessageBox.Show(message);
                    return;
                }
                bool prepared = await executor.PrepareDataAsync(token);

                if (!prepared) continue;

                var benchmarkResult = await executor.RunAsync(token);
                mainList.Add(benchmarkResult.AlgorithmResults.ToList());
            }

            double[] list = new double[vectorLen];

            for (int k = 0; k < vectorLen; k++)
            {
                list[k] = 0;
                for (int i = 0; i < runCount; i++)
                {
                    if (i < mainList.Count && k < mainList[i].Count)
                    {
                        list[k] += mainList[i][k].TimeElapsed.TotalMilliseconds; // Суммируем время
                    }
                }
              
                list[k] /= runCount; // Усредняем
            }

            Points = list.ToList();
            UpdatePlot();
        }

        private void UpdatePlot()
        {
            MyModel.Series.Clear();
            LineSeries lineSeries = new LineSeries();
            Points[0] = Points[1];
            for (int i = 0; i < Points.Count; i++)
            {
                if(i != 0 && i != Points.Count - 1)
                {
                    if (Math.Abs(Points[i] - Points[i - 1]) > 50 || Math.Abs(Points[i] - Points[i + 1]) > 50)
                    {
                        Points[i] = (Points[i - 1] + Points[i + 1]) / 2;
                    }
                }
                lineSeries.Points.Add(new DataPoint(i, Points[i]));
            }

            MyModel.Series.Add(lineSeries);
            AddPolynomialTrendLine(lineSeries, 2); // 2 - это степень полинома
            MyModel.InvalidatePlot(true); // Обновление графика
        }

        private void AddPolynomialTrendLine(LineSeries originalSeries, int degree)
        {
            var trendSeries = new LineSeries { Title = "Линия тренда", StrokeThickness = 2, Color = OxyColors.Red };

            double[] xValues = Enumerable.Range(0, Points.Count).Select(i => (double)i).ToArray();
            double[] yValues = Points.ToArray();

            // Рассчитываем коэффициенты для полинома
            double[] coefficients = PolynomialRegression(xValues, yValues, degree);
            
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("f(x)=");
            // Добавляем точки линии тренда
            for (int i = 0; i < xValues.Length; i++)
            {
                double trendY = 0;
                for (int j = 0; j <= degree; j++)
                {
                    trendY += coefficients[j] * Math.Pow(xValues[i], j);
                    if (i == 0)
                    {
                        stringBuilder.Append(coefficients[j]).Append(" * ").Append("x^").Append(j);

                        if (j != degree)
                        {
                            stringBuilder.Append(" + ");
                        }
                    }
                }
                trendSeries.Points.Add(new DataPoint(xValues[i], trendY));
            }
            aprPolin = stringBuilder;

            MyModel.Series.Add(trendSeries);
        }

        private double[] PolynomialRegression(double[] x, double[] y, int degree)
        {
            int n = x.Length;
            var X = new double[n, degree + 1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= degree; j++)
                {
                    X[i, j] = Math.Pow(x[i], j);
                }
            }

            var coefficients = new double[degree + 1];
            var Xt = new double[degree + 1, n];
            var XtX = new double[degree + 1, degree + 1];
            var XtY = new double[degree + 1];

            // Транспонирование
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= degree; j++)
                {
                    Xt[j, i] = X[i, j];
                }
            }

            // Умножаем Xt на X
            for (int i = 0; i <= degree; i++)
            {
                for (int j = 0; j <= degree; j++)
                {
                    XtX[i, j] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        XtX[i, j] += Xt[i, k] * X[k, j];
                    }
                }
            }

            // Умножаем Xt на Y
            for (int i = 0; i <= degree; i++)
            {
                XtY[i] = 0;
                for (int k = 0; k < n; k++)
                {
                    XtY[i] += Xt[i, k] * y[k];
                }
            }

            // Решаем систему линейных уравнений XtX * coefficients = XtY
            var matrix = new MathNet.Numerics.LinearAlgebra.Double.DenseMatrix(degree + 1, degree + 1, XtX.Cast<double>().ToArray());
            var vector = new MathNet.Numerics.LinearAlgebra.Double.DenseVector(XtY);
            var result = matrix.Solve(vector);

            for (int i = 0; i < coefficients.Length; i++)
            {
                coefficients[i] = result[i];
            }

            return coefficients;
        }
    }
}

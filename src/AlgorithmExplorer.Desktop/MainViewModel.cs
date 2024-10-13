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
using AlgorithmExplorer.Application.ExecutionCoordinators.Base;

namespace AlgorithmExplorer.Desktop
{
    public class MainViewModel
    {
        public PlotModel MyModel { get; private set; }
        public IList<double> Points { get; private set; }
        public StringBuilder aprPolin {  get; private set; }
        public double deviation { get; private set; }
        private List<double> deviationApr = new List<double>();

        public MainViewModel()
        {
            MyModel = new PlotModel { Title = "График производительности алгоритма" };
            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Размер вектора" });
            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Время (мс)" });
            Points = new List<double>();
        }

        public async Task GetGraphik(string vectorLength, AlgorithmType alg, string count, IInputExecutorProvider inputData, CancellationToken token, string inpForPow, string inpStartStep, string inpStepType)
        {
            List<List<Core.Benchmarking.AlgorithmRunResult>> mainList = new();
            int vectorLen = int.Parse(vectorLength);
            int runCount = int.Parse(count);

            for (int k = 0; k < runCount; k++)
            {
                var executor = inputData.GetByAlgorithm(alg)!;
                var powOptionInput = new DisplayableOptionInput(new DisplayableCoordinatorOption { DisplayName = "number" }, inpForPow);
                var optionInput = new DisplayableOptionInput(new DisplayableCoordinatorOption { DisplayName = "iterations" }, vectorLength);
                var stepOption = new DisplayableOptionInput(new DisplayableCoordinatorOption { DisplayName = "Step" }, inpStartStep);
                var stepType = new DisplayableOptionInput(new DisplayableCoordinatorOption { DisplayName = "StepType"}, inpStepType);
                var inputs = new DisplayableOptionInputs(alg, new List<DisplayableOptionInput> { optionInput });
                inputs.Inputs.Add(stepOption);
                inputs.Inputs.Add(stepType);
                
                if(alg is AlgorithmType.DefaultPow or AlgorithmType.QuickPow or AlgorithmType.RecursivePow or AlgorithmType.SimplePow)
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

            int step = int.Parse(inpStartStep);
            int iterationNumber = 0;

            for (int k = 0; k < vectorLen; k += step)
            {
                list[iterationNumber] = 0;
                for (int i = 0; i < runCount; i++)
                {
                    if (i < mainList.Count && k < mainList[i].Count)
                    {
                        list[iterationNumber] += mainList[i][k].TimeElapsed.TotalMilliseconds; // Суммируем время
                    }
                }
              
                list[iterationNumber] /= runCount; // Усредняем

                step = GetStep(step, inpStepType, iterationNumber);
                iterationNumber++;
            }

            Points = list.ToList();
            UpdatePlot( int.Parse(inpStartStep), inpStepType);
        }

        private int GetStep(int startStep, string stepType, int iterationNumber)
        {
            if (stepType == "Additive")
            {
                startStep += 10 * (iterationNumber + 1);
            }
            else if (stepType == "Cumulative")
            {

            }
            else
            {
                startStep *= (int)Math.Pow(10, iterationNumber);
            }
            return startStep;
        }

        private void UpdatePlot( int startStep, string stepType)
        {
            MyModel.Series.Clear();
            LineSeries lineSeries = new LineSeries();
            Points[0] = Points[1];
            for (int i = 0; i < Points.Count; i++)
            {
                if (Points[i] == 0 && i != 0)
                {
                    break;
                }
                lineSeries.Points.Add(new DataPoint(GetStep(startStep, stepType, i), Points[i]));
                startStep = GetStep(startStep, stepType, i);
            }

            MyModel.Series.Add(lineSeries);
            AddPolynomialTrendLine(lineSeries, 2); // 2 - это степень полинома
            MyModel.InvalidatePlot(true); // Обновление графика
            for(int i = 0; i < Points.Count-1; i++)
            {
                deviation += (Points[i] + deviationApr[i]) / 2;
            }
            deviation /= Points.Count;
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
                deviationApr.Add(trendY);
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

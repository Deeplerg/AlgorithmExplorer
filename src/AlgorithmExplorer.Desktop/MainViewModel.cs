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
        public StringBuilder aprPolin { get; private set; }
        public double deviation { get; private set; }
        private List<double> deviationApr = new List<double>(1);
        private StepType stepType;
        private int vectorLen;

        public MainViewModel()
        {
            MyModel = new PlotModel { Title = "График производительности алгоритма" };
            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Размер вектора" });
            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Время (мс)" });
            Points = new List<double>();
            deviationApr.Add(0);
        }

        public async Task GetGraphik(string vectorLength, AlgorithmType alg, string count, IInputExecutorProvider inputData, CancellationToken token, string inpForPow, string inpStartStep, string inpStepType)
        {
            List<List<Core.Benchmarking.AlgorithmRunResult>> mainList = new();
            vectorLen = int.Parse(vectorLength);
            int runCount = int.Parse(count);
            stepType = Enum.Parse<StepType>(inpStepType);
            for (int k = 0; k < runCount; k++)
            {
                var executor = inputData.GetByAlgorithm(alg)!;
                var powOptionInput = new DisplayableOptionInput(new DisplayableCoordinatorOption { DisplayName = "number" }, inpForPow);
                var optionInput = new DisplayableOptionInput(new DisplayableCoordinatorOption { DisplayName = "iterations" }, vectorLength);
                var stepOption = new DisplayableOptionInput(new DisplayableCoordinatorOption { DisplayName = "Step" }, inpStartStep);
                var stepType = new DisplayableOptionInput(new DisplayableCoordinatorOption { DisplayName = "StepType" }, inpStepType);
                var inputs = new DisplayableOptionInputs(alg, new List<DisplayableOptionInput> { optionInput });
                inputs.Inputs.Add(stepOption);
                inputs.Inputs.Add(stepType);

                if (alg is AlgorithmType.DefaultPow or AlgorithmType.QuickPow or AlgorithmType.RecursivePow or AlgorithmType.SimplePow)
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


            for (int step = 0; step < vectorLen; step++)
            {
                list[step] = 0;
                for (int i = 0; i < runCount; i++)
                {
                    if (i < mainList.Count && step < mainList[i].Count)
                    {
                        list[step] += mainList[i][step].TimeElapsed.TotalMilliseconds; // Суммируем время
                    }
                }
                list[step] /= runCount; // Усредняем
            }
            list[list.Length - 1] = mainList[0].Last().TimeElapsed.TotalMilliseconds;//[mainList[0].Count() - 1].TimeElapsed.TotalMilliseconds;
            Points = list.ToList();
            UpdatePlot(int.Parse(inpStartStep));
        }

        private int GetStep(int startStep, int iterationNumber)
        {
            if (stepType is StepType.Additive)
            {
                startStep += 0;
            }
            else if (stepType is StepType.Cumulative)
            {
                startStep *= 2;
            }
            else
            {
                startStep *= (int)Math.Pow(3, iterationNumber);
            }
            return startStep;
        }

        private void UpdatePlot(int startStep)
        {
            MyModel.Series.Clear();
            LineSeries lineSeries = new LineSeries();
            Points[0] = Points[startStep];
            int iterationNumber = 0;
            int step = startStep;
            for (int i = 0; i < vectorLen; i += step)
            {
                step = GetStep(step, iterationNumber);
                if (Points[iterationNumber] == 0 && i != 0)
                {
                    continue;
                }
                lineSeries.Points.Add(new DataPoint(i, Points[iterationNumber]));
                iterationNumber++;
            }

            MyModel.Series.Add(lineSeries);
            AddPolynomialTrendLine(lineSeries, 2, startStep); // 2 - это степень полинома
            MyModel.InvalidatePlot(true); // Обновление графика
            for (int i = 0; i < deviationApr.Count - 1; i++)
            {
                deviation += (Points[i] + deviationApr[i]) / 2;
            }
            deviation /= Points.Count;
        }


        private void AddPolynomialTrendLine(LineSeries originalSeries, int degree, int startStep)
        {
            var trendSeries = new LineSeries { Title = "Линия тренда", StrokeThickness = 2, Color = OxyColors.Red };

            // Используем динамический шаг
            List<double> xValuesList = new List<double>();
            List<double> yValuesList = new List<double>();
            int step = startStep;
            int iterationNumber = 0;
            for (int i = 0; i < Points.Count; i += step)
            {
                step = GetStep(step, iterationNumber); 
                xValuesList.Add(i);
                yValuesList.Add(Points[iterationNumber]);
                iterationNumber++;
            }
            double[] xValues = xValuesList.ToArray();
            double[] yValues = yValuesList.ToArray();

            // Рассчитываем коэффициенты для полинома
            double[] coefficients = PolynomialRegression(xValues, yValues, degree);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("f(x)=");

            deviationApr.Clear(); // Очищаем список отклонений перед новым расчетом
            deviationApr.Add(0);  // Добавляем 0 для первой точки

            // Добавляем точки линии тренда
            for (int i = 0; i < xValues.Length; i++)
            {
                double trendY = 0;
                for (int j = 0; j <= degree; j++)
                {
                    trendY += coefficients[j] * Math.Pow(xValues[i], j);
                    if (i == 0 && j == 0)
                    {
                        stringBuilder.Append(coefficients[j]);
                    }
                    else if (i == 0)
                    {
                        stringBuilder.Append(" + ").Append(coefficients[j]).Append(" * x^").Append(j);
                    }
                }

                trendSeries.Points.Add(new DataPoint(xValues[i], trendY));

                // Сохраняем отклонения
                if (i < Points.Count)
                {
                    deviationApr.Add(Points[(int)xValues[i]] - trendY);
                }
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
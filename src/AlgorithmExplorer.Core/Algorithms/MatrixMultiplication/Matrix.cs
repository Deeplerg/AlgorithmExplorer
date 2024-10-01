namespace AlgorithmExplorer.Core.Algorithms.MatrixMultiplication;

public class Matrix
{
    public int Columns;
    public int Rows;
    public int[,] Data;

    public Matrix(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        Data = new int[rows, columns];
    }
}
namespace AlgorithmExplorer.Core.Algorithms.MatrixMultiplication;

public class MatrixMultiplicationAlgorithm : ICancellableAlgorithm<MatrixMultiplicationOptions, MatrixMultiplicationResult>
{
    public CancellableResult<MatrixMultiplicationResult> Run(MatrixMultiplicationOptions options, CancellationToken token)
    {
        var matrixA = options.Left;
        var matrixB = options.Right;
        
        if (matrixA.Rows != matrixB.Columns) throw new ArgumentException("Вспомни условие умножения матриц :)");

        var matrixResult = new Matrix(matrixA.Rows, matrixB.Columns);

        for (var i = 0; i < matrixA.Rows; i++)
        {
            for (var j = 0; j < matrixB.Columns; j++)
            {
                for (var g = 0; g < matrixA.Columns; g++)
                {
                    if(token.IsCancellationRequested)
                        return CancellableResult<MatrixMultiplicationResult>.Empty;
                    
                    matrixResult.Data[i, j] += matrixA.Data[i, g] * matrixB.Data[g, j];
                }
            }
        }

        return new CancellableResult<MatrixMultiplicationResult>
        {
            Result = new MatrixMultiplicationResult(matrixResult)
        };
    }
}
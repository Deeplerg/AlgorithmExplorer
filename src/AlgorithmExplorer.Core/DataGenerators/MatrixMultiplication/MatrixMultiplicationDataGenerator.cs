using AlgorithmExplorer.Core.Algorithms.MatrixMultiplication;

namespace AlgorithmExplorer.Core.DataGenerators.MatrixMultiplication;

public class MatrixMultiplicationDataGenerator : IDataGenerator<MatrixMultiplicationDataGeneratorOptions, MatrixMultiplicationOptions>
{
    public MatrixMultiplicationOptions Generate(MatrixMultiplicationDataGeneratorOptions options)
    {
        var left = GenerateMatrix(options.Size, Random.Shared);
        var right = GenerateMatrix(options.Size, Random.Shared);

        return new MatrixMultiplicationOptions(left, right);
    }
    
    private Matrix GenerateMatrix(int size, Random random)
    {
        var matrix = new Matrix(size, size);

        for (var i = 0; i < size; i++)
            for (var j = 0; j < size; j++)
                matrix.Data[i, j] = random.Next();

        return matrix;
    }
}
using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rows = matrixDimensions[0];
            int columns = matrixDimensions[1];
            string[,] matrix = new string[rows, columns];
            int equalCellsCounter = 0;

            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine().Split();
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if ((row > 0) && (col > 0))
                    {
                        if ((matrix[row, col] == matrix[row, col - 1])
                        && (matrix[row, col] == matrix[row - 1, col])
                        && (matrix[row, col] == matrix[row - 1, col - 1]))
                        {
                            equalCellsCounter++;
                        }
                    }
                }
            }

            Console.WriteLine(equalCellsCounter);
        }
    }
}

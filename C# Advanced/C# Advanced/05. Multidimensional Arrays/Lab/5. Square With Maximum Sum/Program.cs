using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int rows = matrixSize[0];
            int columns = matrixSize[1];

            int[,] matrix = new int[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                int[] currentColumn = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = currentColumn[col];
                }
            }

            int sum = 0;
            int sumMax = Int32.MinValue;
            int rowIndexMax = 0;
            int columnIndexMax = 0;

            for (int col = 0; col < columns - 1; col++)
            {

                for (int row = 0; row < rows - 1; row++)
                {
                    sum = matrix[row, col] + matrix[row, col + 1]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (sum > sumMax)
                    {
                        sumMax = sum;
                        rowIndexMax = row;
                        columnIndexMax = col;
                    }
                }

            }

            Console.WriteLine($"{matrix[rowIndexMax, columnIndexMax]} {matrix[rowIndexMax, columnIndexMax + 1]}");
            Console.WriteLine($"{matrix[rowIndexMax + 1, columnIndexMax]} {matrix[rowIndexMax + 1, columnIndexMax + 1]}");
            Console.WriteLine(sumMax);
        }
    }
}

using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
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
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = currentColumn[col];
                }
            }

            for (int col = 0; col < columns; col++)
            {
                int sum = 0;

                for (int row = 0; row < rows; row++)
                {
                    sum += matrix[row, col];
                }

                Console.WriteLine(sum);
            }
        }
    }
}

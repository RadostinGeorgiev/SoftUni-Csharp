using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = sizeMatrix[0];
            int columns = sizeMatrix[1];
            string[,] matrix = new string[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split();
                int row1 = 0;
                int col1 = 0;
                int row2 = 0;
                int col2 = 0;


                if (command[0] == "swap" && command.Length == 5)
                {
                    row1 = int.Parse(command[1]);
                    col1 = int.Parse(command[2]);
                    row2 = int.Parse(command[3]);
                    col2 = int.Parse(command[4]);

                    if (row1 < 0 || row1 > matrix.GetLength(0) ||
                        col1 < 0 || col1 > matrix.GetLength(1) ||
                        row2 < 0 || row2 > matrix.GetLength(0) ||
                        col2 < 0 || col2 > matrix.GetLength(1))
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        string tempValue = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = tempValue;

                        PrintMatrix(rows, columns, matrix);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static void PrintMatrix(int rows, int columns, string[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}

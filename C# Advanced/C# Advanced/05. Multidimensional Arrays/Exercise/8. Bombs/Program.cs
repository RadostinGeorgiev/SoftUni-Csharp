using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = CreateSquareMatrix(size);

            Queue<int> coordinates = new Queue<int>(Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            while (coordinates.Count > 0)
            {
                int bombRow = coordinates.Dequeue();
                int bombColumn = coordinates.Dequeue();

                int bombPower = matrix[bombRow, bombColumn];
                if (bombPower > 0)
                {
                    ExplodeBomb(matrix, bombRow, bombColumn, bombPower);
                }
            }

            var result = matrix.OfType<int>().Where(value => value > 0);
            Console.WriteLine($"Alive cells: {result.Count()}");
            Console.WriteLine($"Sum: {result.Sum()}");
            PrintMatrix(matrix);
        }

        private static int[,] CreateSquareMatrix(int size)
        {
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static bool CheckCoordinate(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void DamageField(int[,] matrix, int row, int col, int power)
        {
            if (CheckCoordinate(matrix, row, col) && matrix[row, col] > 0)
            {
                matrix[row, col] -= power;
            }
        }

        private static void ExplodeBomb(int[,] matrix, int row, int col, int power)
        {
            DamageField(matrix, row - 1, col - 1, power);
            DamageField(matrix, row - 1, col, power);
            DamageField(matrix, row - 1, col + 1, power);
            DamageField(matrix, row, col - 1, power);
            DamageField(matrix, row, col, power);
            DamageField(matrix, row, col + 1, power);
            DamageField(matrix, row + 1, col - 1, power);
            DamageField(matrix, row + 1, col, power);
            DamageField(matrix, row + 1, col + 1, power);
        }
    }
}
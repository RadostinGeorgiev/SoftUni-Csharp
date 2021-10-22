using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rowsN = size[0];
            int colsM = size[1];
            int[,] matrix = new int[rowsN, colsM];

            FillMatrix(rowsN, colsM, matrix);

            List<(int, int)> plants = new List<(int, int)>();

            string input;
            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                PlantFlowers(plants, input, matrix);
            }

            BloomFlowers(matrix, plants);
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void BloomFlowers(int[,] matrix, List<(int, int)> plants)
        {
            foreach (var plant in plants)
            {
                int row = plant.Item1;
                int col = plant.Item2;

                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    matrix[row, i]++;
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (i != row) { matrix[i, col]++; }
                }
            }
        }

        private static bool CheckCoordinates(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }

        private static void PlantFlowers(List<(int, int)> plants, string input, int[,] matrix)
        {
            int[] coordinates = input.Split().Select(int.Parse).ToArray();
            int row = coordinates[0];
            int col = coordinates[1];

            if (CheckCoordinates(matrix, row, col))
            {
                plants.Add((row, col));
            }
            else
            {
                Console.WriteLine("Invalid coordinates.");
            }
        }

        private static void FillMatrix(int rowsN, int colsM, int[,] matrix)
        {
            for (int row = 0; row < rowsN; row++)
            {
                for (int col = 0; col < colsM; col++)
                {
                    matrix[row, col] = 0;
                }
            }
        }
    }
}
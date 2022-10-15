namespace _02._Battle_Points
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        public static int[] energy;
        public static int[] points;
        static void Main(string[] args)
        {
            energy = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            points = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int initialEnergy = int.Parse(Console.ReadLine());
            int[,] matrix = CreateMatrix(initialEnergy);
            var selectedItems = GetTakenItems(matrix);

            Console.WriteLine($"{selectedItems.Sum()}");
            //Console.WriteLine($"{string.Join(", ", selectedItems)}");
        }
        public static List<int> GetTakenItems(int[,] matrix)
        {
            List<int> selectedItems = new List<int>();

            int index = matrix.GetLength(0) - 1;
            int capacity = matrix.GetLength(1) - 1;

            while (index > 0 && capacity > 0)
            {
                if (matrix[index, capacity] != matrix[index - 1, capacity])
                {
                    selectedItems.Add(points[index - 1]);

                    capacity -= energy[index - 1];
                }

                index -= 1;
            }

            return selectedItems;
        }
        private static int[,] CreateMatrix(int initialPoints)
        {
            var matrix = new int[energy.Length + 1, initialPoints + 1];

            for (int index = 1; index < matrix.GetLength(0); index++)
            {
                for (int capacity = 1; capacity < matrix.GetLength(1); capacity++)
                {
                    var excluding = matrix[index - 1, capacity];
                    if (energy[index - 1] > capacity)
                    {
                        matrix[index, capacity] = excluding;
                    }
                    else
                    {
                        var including = points[index - 1] + matrix[index - 1, capacity - energy[index - 1]];
                        matrix[index, capacity] = Math.Max(excluding, including);
                    }
                }
            }

            return matrix;
        }
        public static void PrintMatrix(int[,] matrix)
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
    }
}

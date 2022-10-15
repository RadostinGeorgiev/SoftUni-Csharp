namespace _03._Battle_Points
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Enemy
    {
        public int Energy { get; set; }
        public int battlePoints { get; set; }
    }

    internal class Program
    {
        public static List<Enemy> enemies;
        static void Main(string[] args)
        {
            enemies = new List<Enemy>();

            int[] energy = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] points = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int initialEnergy = int.Parse(Console.ReadLine());

            for (int i = 0; i < energy.Length; i++)
            {
                enemies.Add(new Enemy
                {
                    Energy = energy[i],
                    battlePoints = points[i],
                });
            }

            int[,] matrix = CreateMatrix(initialEnergy);
            var selectedItems = GetTakenItems(matrix);

            Console.WriteLine($"{selectedItems.Sum(x => x.battlePoints)}");
        }
        public static List<Enemy> GetTakenItems(int[,] matrix)
        {
            List<Enemy> selectedItems = new List<Enemy>();

            int index = matrix.GetLength(0) - 1;
            int capacity = matrix.GetLength(1) - 1;

            while (index > 0 && capacity > 0)
            {
                if (matrix[index, capacity] != matrix[index - 1, capacity])
                {
                    var item = enemies[index - 1];
                    selectedItems.Add(item);

                    capacity -= item.Energy;
                }

                index -= 1;
            }

            return selectedItems;
        }
        private static int[,] CreateMatrix(int initialPoints)
        {
            var matrix = new int[enemies.Count + 1, initialPoints + 1];

            for (int index = 1; index < matrix.GetLength(0); index++)
            {
                var enemy = enemies[index - 1];

                for (int capacity = 1; capacity < matrix.GetLength(1); capacity++)
                {
                    var excluding = matrix[index - 1, capacity];
                    if (enemy.Energy > capacity)
                    {
                        matrix[index, capacity] = excluding;
                    }
                    else
                    {
                        var including = enemy.battlePoints + matrix[index - 1, capacity - enemy.Energy];
                        matrix[index, capacity] = Math.Max(excluding, including);
                    }
                }
            }

            return matrix;
        }
    }
}

namespace _02._Battle_Points
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Enemy
    {
        public int Index { get; set; }
        public int Energy { get; set; }
        public int battlePoints { get; set; }
        public override string ToString()
        {
            return string.Format($"[{this.Index}] {this.Energy} -> {this.battlePoints}");
        }

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
                    Index = i,
                    Energy = energy[i],
                    battlePoints = points[i],
                });
            }

            int[,] matrix = CreateMatrix(initialEnergy);

            Stack<Enemy> selectedItems = GetTakenItems(matrix);
            Console.WriteLine($"{selectedItems.Sum(x => x.battlePoints)}");
            //Console.WriteLine($"Total Energy: {selectedItems.Sum(x => x.Energy)}");
            //foreach (var enemy in selectedItems)
            //{
            //    Console.WriteLine(enemy);
            //}

            //var allItems = GetAllTakenItems(matrix);
            //foreach (var enemy in allItems)
            //{
            //    Console.WriteLine($"{string.Join(Environment.NewLine, enemy)}");
            //    Console.WriteLine($"Total Energy: {enemy.Sum(x => x.Energy)}");
            //    Console.WriteLine($"Total BattlePoints: {enemy.Sum(x => x.battlePoints)}");
            //    Console.WriteLine();
            //}
        }

        public static Stack<Enemy> GetTakenItems(int[,] matrix)                             //Get best variant
        {
            Stack<Enemy> selectedItems = new Stack<Enemy>();

            int index = matrix.GetLength(0) - 1;
            int capacity = matrix.GetLength(1) - 1;

            while (index > 0 && capacity > 0)
            {
                if (matrix[index, capacity] != matrix[index - 1, capacity])
                {
                    var item = enemies[index - 1];
                    selectedItems.Push(item);

                    capacity -= item.Energy;
                }

                index -= 1;
            }

            return selectedItems;
        }

        private static List<List<Enemy>> GetAllTakenItems(int[,] matrix)                    //Get all of possible variants
        {
            List<List<Enemy>> allSelectedItems = new List<List<Enemy>>();
            Stack<Enemy> maxItems = new Stack<Enemy>();

            int index = matrix.GetLength(0) - 1;
            int capacity = matrix.GetLength(1) - 1;

            Select(index, capacity, 0);

            return allSelectedItems;

            void Select(int i, int j, int k)
            {
                Enemy item;
                if (i == 0)
                {
                    return;
                }

                if (j == 0)
                {
                    //foreach (var element in maxItems)
                    //{
                    //    Console.WriteLine(element);
                    //}
                    allSelectedItems.Add(maxItems.ToList());
                    maxItems.Clear();
                }
                else
                {
                    item = enemies[i - 1];
                    if (matrix[i, j] == matrix[i - 1, j])
                    {
                        Select(i - 1, j, k);
                    }

                    if (j >= item.Energy &&
                        matrix[i, j] == matrix[i - 1, j - item.battlePoints] + item.battlePoints)
                    {
                        maxItems.Push(item);
                        Select(i - 1, j - item.Energy, k + 1);
                    }
                }
            }
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

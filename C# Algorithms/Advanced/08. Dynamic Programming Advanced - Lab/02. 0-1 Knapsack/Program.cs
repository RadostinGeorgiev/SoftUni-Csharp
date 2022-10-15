namespace _02._0_1_Knapsack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Item : IComparable<Item>
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }

        public int CompareTo(Item other)
        {
            int result = this.Name.CompareTo(other.Name);
            return result;
        }
        public override string ToString()
        {
            return string.Format($"{this.Weight} -> {this.Value}");
        }

    }
    internal class Program
    {
        private static List<Item> items;
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            items = new List<Item>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] itemData = input.Split(' ');

                items.Add(new Item
                {
                    Name = itemData[0],
                    Weight = int.Parse(itemData[1]),
                    Value = int.Parse(itemData[2]),
                });
            }

            int[,] matrix = CreateMatrix(maxCapacity);

            var selectedItems = GetTakenItems(matrix);

            Console.WriteLine($"Total Weight: {selectedItems.Sum(x => x.Weight)}");
            Console.WriteLine($"Total Value: {selectedItems.Sum(x => x.Value)}");
            foreach (var item in selectedItems)
            {
                Console.WriteLine(item.Name);
            }            
        }

        private static SortedSet<Item> GetTakenItems(int[,] matrix)                         //Get one of possible variants
        {
            SortedSet<Item> selectedItems = new SortedSet<Item>();

            int index = matrix.GetLength(0) - 1;
            int capacity = matrix.GetLength(1) - 1;

            while (index > 0 && capacity > 0)
            {
                if (matrix[index, capacity] != matrix[index - 1, capacity])
                {
                    var item = items[index - 1];
                    selectedItems.Add(item);

                    capacity -= item.Weight;
                }

                index -= 1;
            }

            return selectedItems;
        }

        private static SortedSet<Item> GetAllTakenItems(int[,] matrix)                     //Get all of possible variants
        {
            SortedSet<Item> allSelectedItems = new SortedSet<Item>();
            List<Item> maxItems = new List<Item>();

            int index = matrix.GetLength(0) - 1;
            int capacity = matrix.GetLength(1) - 1;

            Select(index, capacity, 0);

            return allSelectedItems;

            void Select(int i, int j, int k)
            {
                Item item;

                if (j == 1)
                {
                    for (int idx = 1; idx < k; idx++)
                    {
                        item = items[idx - 1];
                        allSelectedItems.Add(item);
                    }

                    return;
                }

                item = items[i - 1];
                if (matrix[i, j] == matrix[i - 1, j])
                    Select(i - 1, j, k);

                if (j >= item.Weight &&
                    matrix[i, j] == matrix[i - 1, j - item.Value] + item.Value)
                {
                    maxItems.Add(item);
                    Select(i - 1, j - item.Weight, k + 1);
                }

            }
        }

        private static int[,] CreateMatrix(int maxCapacity)
        {
            var matrix = new int[items.Count + 1, maxCapacity + 1];

            for (int index = 1; index < matrix.GetLength(0); index++)
            {
                var item = items[index - 1];

                for (int capacity = 1; capacity < matrix.GetLength(1); capacity++)
                {
                    var excluding = matrix[index - 1, capacity];
                    if (item.Weight > capacity)
                    {
                        matrix[index, capacity] = excluding;
                    }
                    else
                    {
                        var including = item.Value + matrix[index - 1, capacity - item.Weight];
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

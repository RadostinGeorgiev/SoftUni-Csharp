namespace _03._Road_Trip
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Item
    {
        public int Weight { get; set; }
        public int Value { get; set; }
    }

    internal class Program
    {
        private static List<Item> items;

        static void Main(string[] args)
        {
            items = new List<Item>();

            int[] values = Console.ReadLine()
                                  .Split(", ")
                                  .Select(int.Parse)
                                  .ToArray();

            int[] spaces = Console.ReadLine()
                                  .Split(", ")
                                  .Select(int.Parse)
                                  .ToArray();
            int maxCapacity = int.Parse(Console.ReadLine());

            for (int i = 0; i < values.Length; i++)
            {
                items.Add(new Item
                {
                    Weight = spaces[i],
                    Value = values[i],
                });
            }

            int[,] matrix = CreateMatrix(maxCapacity);
            List<Item> selectedItems = GetTakenItems(matrix);

            //Console.WriteLine($"Maximum value: {matrix[values.Length, maxCapacity]}");
            //Console.WriteLine($"Total space: {selectedItems.Sum(x => x.Weight)}");
            Console.WriteLine($"Maximum value: {selectedItems.Sum(x => x.Value)}");

            //foreach (var item in selectedItems)
            //{
            //    Console.WriteLine($"{item.Weight} => {item.Value}");
            //}
        }

        private static List<Item> GetTakenItems(int[,] matrix)
        {
            List<Item> selectedItems = new List<Item>();

            int index = matrix.GetLength(0) - 1;
            int capacity = matrix.GetLength(1) - 1;

            while (index > 0 && capacity > 0)
            {
                if (matrix[index, capacity] != matrix[index - 1, capacity])
                {
                    Item item = items[index - 1];
                    selectedItems.Add(item);

                    capacity -= item.Weight;
                }

                index -= 1;
            }

            return selectedItems;
        }

        private static int[,] CreateMatrix(int maxCapacity)
        {
            int[,] matrix = new int[items.Count + 1, maxCapacity + 1];

            for (int index = 1; index < matrix.GetLength(0); index++)
            {
                Item item = items[index - 1];

                for (int capacity = 1; capacity < matrix.GetLength(1); capacity++)
                {
                    int excluding = matrix[index - 1, capacity];

                    if (item.Weight > capacity)
                    {
                        matrix[index, capacity] = excluding;
                    }
                    else
                    {
                        int including = item.Value + matrix[index - 1, capacity - item.Weight];
                        matrix[index, capacity] = Math.Max(excluding, including);
                    }
                }
            }

            return matrix;
        }
    }
}
namespace _03._Medivac
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Unit : IComparable<Unit>
    {
        public int Number { get; set; }
        public int Capacity { get; set; }
        public int urgencyRating { get; set; }

        public int CompareTo(Unit other)
        {
            int result = this.Number.CompareTo(other.Number);
            return result;
        }
        public override string ToString()
        {
            return string.Format($"{this.Capacity} -> {this.urgencyRating}");
        }

    }
    internal class Program
    {
        private static List<Unit> items;
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            items = new List<Unit>();

            string input;
            while ((input = Console.ReadLine()) != "Launch")
            {
                string[] itemData = input.Split(' ');

                items.Add(new Unit
                {
                    Number = int.Parse(itemData[0]),
                    Capacity = int.Parse(itemData[1]),
                    urgencyRating = int.Parse(itemData[2]),
                });
            }

            int[,] matrix = CreateMatrix(maxCapacity);

            var selectedItems = GetTakenItems(matrix);

            Console.WriteLine($"{selectedItems.Sum(x => x.Capacity)}");
            Console.WriteLine($"{selectedItems.Sum(x => x.urgencyRating)}");
            foreach (var item in selectedItems)
            {
                Console.WriteLine(item.Number);
            }            
        }

        private static SortedSet<Unit> GetTakenItems(int[,] matrix)                         
        {
            SortedSet<Unit> selectedItems = new SortedSet<Unit>();

            int index = matrix.GetLength(0) - 1;
            int capacity = matrix.GetLength(1) - 1;

            while (index > 0 && capacity > 0)
            {
                if (matrix[index, capacity] != matrix[index - 1, capacity])
                {
                    var item = items[index - 1];
                    selectedItems.Add(item);

                    capacity -= item.Capacity;
                }

                index -= 1;
            }

            return selectedItems;
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
                    if (item.Capacity > capacity)
                    {
                        matrix[index, capacity] = excluding;
                    }
                    else
                    {
                        var including = item.urgencyRating + matrix[index - 1, capacity - item.Capacity];
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

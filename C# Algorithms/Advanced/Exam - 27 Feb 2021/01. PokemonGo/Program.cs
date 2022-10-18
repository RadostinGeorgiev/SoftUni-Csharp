namespace _01._PokemonGo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Street : IComparable<Street>
    {
        public string Name { get; set; }
        public int Length { get; set; }                                             //Weight
        public int PockemonCount { get; set; }                                      //Value

        public int CompareTo(Street other)
        {
            int result = this.Name.CompareTo(other.Name);
            return result;
        }

        public override string ToString()
        {
            return string.Format($"{this.Name}");
        }
    }

    internal class Program
    {
        private static List<Street> items;

        static void Main(string[] args)
        {
            int fuel = int.Parse(Console.ReadLine());                             //maxCapacity
            items = new List<Street>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] itemData = input.Split(", ");

                items.Add(new Street
                {
                    Name = itemData[0],
                    Length = int.Parse(itemData[2]),
                    PockemonCount = int.Parse(itemData[1]),
                });
            }

            int[,] matrix = CreateMatrix(fuel);

            SortedSet<Street> checkedStreets = GetTakenItems(matrix);

            Console.WriteLine($"{string.Join(" -> ", checkedStreets)}");
            Console.WriteLine($"Total Pokemon caught -> {checkedStreets.Sum(x => x.PockemonCount)}");
            Console.WriteLine($"Fuel Left -> {fuel - checkedStreets.Sum(x => x.Length)}");
        }

        private static SortedSet<Street> GetTakenItems(int[,] matrix)
        {
            SortedSet<Street> checkedStreets = new SortedSet<Street>();

            int index = matrix.GetLength(0) - 1;
            int capacity = matrix.GetLength(1) - 1;

            while (index > 0 && capacity > 0)
            {
                if (matrix[index, capacity] != matrix[index - 1, capacity])
                {
                    Street street = items[index - 1];
                    checkedStreets.Add(street);

                    capacity -= street.Length;
                }

                index -= 1;
            }

            return checkedStreets;
        }

        private static int[,] CreateMatrix(int maxCapacity)
        {
            int[,] matrix = new int[items.Count + 1, maxCapacity + 1];

            for (int index = 1; index < matrix.GetLength(0); index++)
            {
                Street item = items[index - 1];

                for (int capacity = 1; capacity < matrix.GetLength(1); capacity++)
                {
                    int excluding = matrix[index - 1, capacity];

                    if (item.Length > capacity)
                    {
                        matrix[index, capacity] = excluding;
                    }
                    else
                    {
                        int including = item.PockemonCount + matrix[index - 1, capacity - item.Length];
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
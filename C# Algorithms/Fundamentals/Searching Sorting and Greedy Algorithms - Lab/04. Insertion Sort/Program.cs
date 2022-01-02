namespace _04._Insertion_Sort
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            InsertionSort(numbers);
            Console.WriteLine(string.Join(' ', numbers));
        }

        private static void InsertionSort(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                var j = i;

                while (j > 0 && numbers[j - 1] > numbers[j])
                {
                    Swap(numbers, j - 1, j);
                    j--;
                }
            }
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            (numbers[first], numbers[second]) = (numbers[second], numbers[first]);
        }
    }
}
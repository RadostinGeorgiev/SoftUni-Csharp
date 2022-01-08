namespace _02._Selection_Sort
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

            SelectionSort(numbers);
            Console.WriteLine(string.Join(' ', numbers));
        }

        private static void SelectionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var minIndex = i;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[minIndex])
                    {
                        minIndex = j;
                    }
                }

                Swap(numbers, i, minIndex);
            }
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            (numbers[first], numbers[second]) = (numbers[second], numbers[first]);
        }
    }
}
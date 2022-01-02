namespace _03._Bubble_Sort
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

            BubbleSort(numbers);
            Console.WriteLine(string.Join(' ', numbers));
        }

        private static void BubbleSort(int[] numbers)
        {
            int sortedElements = 0;
            var IsSorted = false;

            while (!IsSorted)
            {
                IsSorted = true;
                for (int j = 1; j < numbers.Length - sortedElements; j++)
                {
                    if (numbers[j - 1] > numbers[j])
                    {
                        IsSorted = false;
                        Swap(numbers, j - 1, j);
                    }
                }

                sortedElements++;
            }
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            (numbers[first], numbers[second]) = (numbers[second], numbers[first]);
        }
    }
}
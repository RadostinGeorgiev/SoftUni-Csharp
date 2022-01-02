namespace _01._Binary_Search
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
            int searchedNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(numbers, searchedNumber));
        }

        private static int BinarySearch(int[] numbers, int searchedNumber)
        {
            int leftIndex = 0;
            int rightIndex = numbers.Length - 1;

            while (leftIndex <= rightIndex)
            {
                int midIndex = (leftIndex + rightIndex) / 2;

                if (numbers[midIndex] == searchedNumber)
                {
                    return midIndex;
                }

                if (numbers[midIndex] < searchedNumber)
                {
                    leftIndex = midIndex + 1;
                }
                else
                {
                    rightIndex = midIndex - 1;
                }
            }

            return -1;
        }
    }
}
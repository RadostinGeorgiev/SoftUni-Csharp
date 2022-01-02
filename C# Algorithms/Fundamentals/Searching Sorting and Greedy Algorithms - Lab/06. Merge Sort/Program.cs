namespace _06._Merge_Sort
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

            Console.WriteLine(string.Join(' ', MergeSort(numbers)));
        }

        private static int[] MergeSort(int[] array)
        {
            if (array.Length == 1)
            {
               return array; 
            }

            var left = array.Take(array.Length / 2).ToArray();
            var right = array.Skip(array.Length / 2).ToArray();

            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] leftArray, int[] rightArray)
        {
            int[] mergedArray = new int[leftArray.Length + rightArray.Length];

            int leftIndex = 0;
            int rightIndex = 0;
            int mergedIndex = 0;

            while (leftIndex < leftArray.Length &&
                   rightIndex < rightArray.Length)
            {
                if (leftArray[leftIndex] <= rightArray[rightIndex])
                {
                    mergedArray[mergedIndex++] = leftArray[leftIndex++];
                }
                else
                {
                    mergedArray[mergedIndex++] = rightArray[rightIndex++];
                }
            }

            for (int i = leftIndex; i < leftArray.Length; i++)
            {
                mergedArray[mergedIndex++] = leftArray[i];
            }

            for (int i = rightIndex; i < rightArray.Length; i++)
            {
                mergedArray[mergedIndex++] = rightArray[i];
            }

            return mergedArray;
        }
    }
}
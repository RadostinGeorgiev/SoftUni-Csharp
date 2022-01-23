namespace _01._Super_Set
{
    using System;
    using System.Linq;

    class Program
    {
        private static int[] elements;
        private static int[] combinations;

        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int k = 0; k <= elements.Length; k++)
            {
                combinations = new int[k];

                GetCombinations(0, 0);
            }
        }

        private static void GetCombinations(int index, int elementsIndex)
        {
            if (index == combinations.Length)
            {
                Console.WriteLine(string.Join(' ', combinations));
                return;
            }

            for (int i = elementsIndex; i < elements.Length; i++)
            {
                combinations[index] = elements[i];
                GetCombinations(index + 1, i + 1);
            }
        }
    }
}
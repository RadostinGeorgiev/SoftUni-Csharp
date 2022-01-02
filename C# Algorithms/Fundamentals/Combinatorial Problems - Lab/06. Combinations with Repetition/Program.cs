namespace _06._Combinations_with_Repetition
{
    using System;
    using System.Linq;

    class Program
    {
        private static char[] elements;
        private static char[] combinations;

        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
            int k = int.Parse(Console.ReadLine());

            combinations = new char[k];

            GetCombinations(0, 0);
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
                GetCombinations(index + 1, i);
            }
        }
    }
}

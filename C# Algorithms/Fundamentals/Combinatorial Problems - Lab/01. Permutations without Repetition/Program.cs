namespace _01._Permutations_without_Repetition
{
    using System;
    using System.Linq;

    class Program
    {
        private static char[] elements;
        private static char[] permutations;
        private static bool[] used;

        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
            permutations = new char[elements.Length];
            used = new bool[elements.Length];

            GetPermutations(0);
        }

        private static void GetPermutations(int index)
        {
            if (index == permutations.Length)
            {
                Console.WriteLine(string.Join(' ', permutations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (used[i]) continue;

                used[i] = true;

                permutations[index] = elements[i];
                GetPermutations(index + 1);

                used[i] = false;
            }
        }
    }
}
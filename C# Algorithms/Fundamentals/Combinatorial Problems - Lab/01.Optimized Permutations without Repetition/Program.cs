namespace _01._Optimized_Permutations_without_Repetition
{
    using System;
    using System.Linq;

    class Program
    {
        private static char[] elements;

        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            GetPermutations(0);
        }

        private static void GetPermutations(int index)
        {
            if (index == elements.Length)
            {
                Console.WriteLine(string.Join(' ', elements));
                return;
            }

            GetPermutations(index + 1);

            for (int i = index + 1; i < elements.Length; i++)
            {
                Swap(index, i);
                GetPermutations(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int index1, int index2)
        {
            var temp = elements[index1];
            elements[index1] = elements[index2];
            elements[index2] = temp;
        }
    }
}
namespace _02._Permutations_with_Repetitions
{
    using System;
    using System.Collections.Generic;
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

            HashSet<char> usedElements = new HashSet<char> { elements[index] };

            for (int i = index + 1; i < elements.Length; i++)
            {
                if (!usedElements.Contains(elements[i]))
                {
                    Swap(index, i);
                    GetPermutations(index + 1);
                    Swap(index, i);

                    usedElements.Add(elements[i]);
                }
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

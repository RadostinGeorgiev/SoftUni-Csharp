namespace _02._Permutations_with_Repetitions
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static char[] elements = new[] { 'A', 'B', 'B' };
        private HashSet<char> usedElements = new HashSet<char>();

        static void Main(string[] args)
        {

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

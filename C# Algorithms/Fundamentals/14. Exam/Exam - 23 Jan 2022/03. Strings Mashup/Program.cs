namespace _03._Strings_Mashup
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static char[] elements;
        private static List<string> permutations;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().ToUpper().ToCharArray();
            permutations = new List<string>();

            GetPermutations(0);
            Console.WriteLine(string.Join(Environment.NewLine, permutations));
        }

        private static void GetPermutations(int index)
        {
            if (index >= elements.Length)
            {
                permutations.Add(new string(elements));
                return;
            }

            GetPermutations(index + 1);

            if (!char.IsLetter(elements[index])) return;

            elements[index] = char.ToLower(elements[index]);
            GetPermutations(index + 1);
            elements[index] = char.ToUpper(elements[index]);
        }
    }
}
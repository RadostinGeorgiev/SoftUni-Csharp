namespace _04._Variations_with_Repetition
{
    using System;
    using System.Linq;

    class Program
    {
        private static char[] elements;
        private static char[] variations;

        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
            int k = int.Parse(Console.ReadLine());
            variations = new char[k];


            GetVariations(0);
        }

        private static void GetVariations(int index)
        {
            if (index == variations.Length)
            {
                Console.WriteLine(string.Join(' ', variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                variations[index] = elements[i];
                GetVariations(index + 1);
            }
        }
    }
}

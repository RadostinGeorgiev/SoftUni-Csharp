namespace _03._Variations_without_Repetition
{
    using System;
    using System.Linq;

    class Program
    {
        private static char[] elements;
        private static bool[] used;
        private static char[] variations;

        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
            used = new bool[elements.Length];
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
                if (!used[i])
                {
                    used[i] = true;

                    variations[index] = elements[i];
                    GetVariations(index + 1);

                    used[i] = false;
                }
            }
        }
    }
}
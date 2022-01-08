namespace Cinema
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        private static List<string> names;
        private static string[] seats;
        private static bool[] locked;

        static void Main(string[] args)
        {
            names = Console.ReadLine()
                .Split(", ")
                .ToList();
            seats = new string[names.Count];
            locked = new bool[names.Count];

            string input;
            while ((input = Console.ReadLine()) != "generate")
            {
                var info = input.Split(" - ").ToArray();
                var name = info[0];
                var pos = int.Parse(info[1]);

                seats[pos - 1] = name;
                locked[pos - 1] = true;
                names.Remove(name);
            }

            GetPermutations(0);
        }

        private static void GetPermutations(int index)
        {
            if (index == names.Count)
            {
                PrintResult();
                return;
            }

            GetPermutations(index + 1);

            for (int i = index + 1; i < names.Count; i++)
            {
                Swap(index, i);
                GetPermutations(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = names[first];
            names[first] = names[second];
            names[second] = temp;
        }

        private static void PrintResult()
        {
            var index = 0;
            for (int i = 0; i < seats.Length; i++)
            {
                if (!locked[i])
                {
                    seats[i] = names[index++];
                }
            }

            Console.WriteLine(string.Join(' ', seats));
        }
    }
}
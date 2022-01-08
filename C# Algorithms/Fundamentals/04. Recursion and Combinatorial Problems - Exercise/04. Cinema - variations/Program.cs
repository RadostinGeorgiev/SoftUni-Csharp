namespace Cinema
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        private static List<string> names;
        private static bool[] used;
        private static string[] seats;
        private static bool[] locked;
        private static string[] variations;

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

            used = new bool[names.Count];
            variations = new string[seats.Length - names.Count];
            GetVariations(0);
        }

        private static void GetVariations(int index)
        {
            if (index == variations.Length)
            {
                PrintResult();
                return;
            }

            for (int i = 0; i < names.Count; i++)
            {

                if (!used[i])
                {
                    used[i] = true;

                    variations[index] = names[i];
                    GetVariations(index + 1);

                    used[i] = false;
                }
            }
        }

        private static void PrintResult()
        {
            StringBuilder sb = new StringBuilder();

            var index = 0;
            for (int i = 0; i < seats.Length; i++)
            {
                sb.Append(locked[i] ? $"{seats[i]} " : $"{names[index++]} ");
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
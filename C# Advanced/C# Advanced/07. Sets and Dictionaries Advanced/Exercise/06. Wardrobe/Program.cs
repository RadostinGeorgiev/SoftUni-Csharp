using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            int number = int.Parse(Console.ReadLine());
            string color = string.Empty;

            for (int i = 1; i <= number; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");

                color = input[0];
                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }

                string[] items = input[1].Split(",");
                foreach (var item in items)
                {
                    if (!clothes[color].ContainsKey(item))
                    {
                        clothes[color].Add(item, 0);
                    }

                    clothes[color][item]++;
                }
            }

            string[] task = Console.ReadLine().Split();
            color = task[0];
            string clothing = task[1];

            foreach (var kVP in clothes)
            {
                Console.WriteLine($"{kVP.Key} clothes:");
                foreach (var item in kVP.Value)
                {
                    Console.WriteLine(kVP.Key == color && item.Key == clothing
                        ? $"* {item.Key} - {item.Value} (found!)"
                        : $"* {item.Key} - {item.Value}");
                }
            }
        }
    }
}
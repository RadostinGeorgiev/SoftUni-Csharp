using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forceBook = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                string forceSide = string.Empty;
                string forceUser = string.Empty;

                if (input.Contains("->"))
                {
                    string[] command = input.Split(" -> ");
                    forceUser = command[0];
                    forceSide = command[1];

                    if (forceBook.Values.Any(d => d.Contains(forceUser)))
                    {
                        string oldKey = forceBook.First(x => x.Value.Contains(forceUser)).Key;
                        forceBook[oldKey].Remove(forceUser);
                        AddValue(forceBook, forceSide, forceUser);
                    }
                    else
                    {
                        AddValue(forceBook, forceSide, forceUser);
                    }

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
                else
                {
                    string[] command = input.Split(" | ");
                    forceSide = command[0];
                    forceUser = command[1];

                    AddValue(forceBook, forceSide, forceUser);
                }

                input = Console.ReadLine();
            }


            foreach (var keyValuePair in forceBook
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                if (keyValuePair.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {keyValuePair.Key}, Members: {keyValuePair.Value.Count}");
                    foreach (string s in keyValuePair.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {s}");
                    }
                }
            }
        }

        private static void AddValue(Dictionary<string, List<string>> dictionary, string key, string value)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, new List<string>());
            }
            if (!dictionary.Values.Any(d => d.Contains(value)))
            {
                dictionary[key].Add(value);
            }
        }
    }
}

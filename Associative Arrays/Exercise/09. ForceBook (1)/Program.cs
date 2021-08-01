using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._ForceBook__1_
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> forceBook = new Dictionary<string, string>();

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

                    if (!forceBook.ContainsKey(forceUser))
                    {
                        forceBook.Add(forceUser, forceSide);
                    }
                    else
                    {
                        forceBook[forceUser] = forceSide;
                    }

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
                else
                {
                    string[] command = input.Split(" | ");
                    forceSide = command[0];
                    forceUser = command[1];

                    if (!forceBook.ContainsKey(forceUser))
                    {
                        forceBook.Add(forceUser, forceSide);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var keyValuePair in forceBook
                .GroupBy(x => x.Value)
                .OrderByDescending(x => x.Count())
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {keyValuePair.Key}, Members: {keyValuePair.Count()}");

                foreach (var valuePair in keyValuePair.OrderBy(x=>x.Key))
                {
                    Console.WriteLine($"! {valuePair.Key}");
                }
            }
        }
    }
}

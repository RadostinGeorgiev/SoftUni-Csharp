using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> racers = new Dictionary<string, int>();

            string input = Console.ReadLine();

            string namePattern = @"[A-Za-z]+";
            string distancePattern = @"\d";

            while (input != "end of race")
            {
                string name = String.Join("",Regex.Matches(input, namePattern)
                    .Select(x=>x.Value));
                int distance = Regex.Matches(input, distancePattern)
                    .Select(x=> int.Parse(x.Value))
                    .Sum();

                if (names.Contains(name))
                {
                    if (racers.ContainsKey(name))
                    {
                        racers[name] += distance;
                    }
                    else
                    {
                        racers.Add(name, distance);
                    }
                }

                input = Console.ReadLine();
            }

            string[] result = racers
                .OrderByDescending(x => x.Value)
                .Select(x => x.Key)
                .Take(3)
                .ToArray();
            Console.WriteLine($"1st place: {result[0]}");
            Console.WriteLine($"2nd place: {result[1]}");
            Console.WriteLine($"3rd place: {result[2]}");
        }
    }
}

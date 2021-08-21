using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.International_SoftUniada
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, Dictionary<string, int>> contestants = new Dictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] text = input
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string countryName = text[0];
                string contestantName = text[1];
                int contestantPoints = int.Parse(text[2]);

                if (!contestants.ContainsKey(countryName))
                {
                    contestants.Add(countryName, new Dictionary<string, int>() { { contestantName, contestantPoints } });
                }
                else
                {
                    if (!contestants[countryName].ContainsKey(contestantName))
                    {
                        contestants[countryName].Add(contestantName, contestantPoints);
                    }
                    else
                    {
                        contestants[countryName][contestantName] += contestantPoints;
                    }
                }
            }

            foreach (var keyValuePair in contestants
                .OrderByDescending(x=>x.Value.Values.Sum()))
            {
                Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value.Values.Sum()}");
                foreach (var valuePair in keyValuePair.Value)
                {
                    Console.WriteLine($"-- {valuePair.Key} -> {valuePair.Value}");
                }
            }
        }
    }
}

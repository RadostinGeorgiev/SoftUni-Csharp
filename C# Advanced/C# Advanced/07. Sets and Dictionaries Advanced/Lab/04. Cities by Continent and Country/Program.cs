using System;
using System.Collections.Generic;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> cities =
                new Dictionary<string, Dictionary<string, List<string>>>();

            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                string[] info = Console.ReadLine().Split();
                string continent = info[0];
                string country = info[1];
                string city = info[2];

                if (!cities.ContainsKey(continent))
                {
                    cities.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!cities[continent].ContainsKey(country))
                {
                    cities[continent].Add(country, new List<string>());
                }

                cities[continent][country].Add(city);
            }

            foreach (var keyValuePair in cities)
            {
                Console.WriteLine($"{keyValuePair.Key}:");
                foreach (var valuePair in keyValuePair.Value)
                {
                    Console.WriteLine($"  {valuePair.Key} -> {string.Join(", ", valuePair.Value)}");
                }
            }
        }
    }
}

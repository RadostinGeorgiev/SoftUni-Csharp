using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string location = Console.ReadLine();
            List<string> destinations = new List<string>();

            string pattern = @"([=\/])(?<location>[A-Z][A-Za-z]{2,})\1";
            int points = 0;

            if (Regex.IsMatch(location, pattern))
            {
                var matches = Regex.Matches(location, pattern);

                foreach (Match match in matches)
                {
                    string destination = match.Groups["location"].Value;
                    destinations.Add(destination);
                    points += destination.Length;
                }
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {points}");
        }
    }
}

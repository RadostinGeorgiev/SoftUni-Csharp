using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace _03._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;
            Dictionary<string, List<int>> townData = new Dictionary<string, List<int>>();
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] town = input.Split("||");
                string name = town[0];
                int population = int.Parse(town[1]);
                int gold = int.Parse(town[2]);
                if (townData.ContainsKey(name))
                {
                    townData[name][0] += population;
                    townData[name][1] += gold;
                }
                else
                {
                    townData.Add(name, new List<int>() { population, gold });
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input.Split("=>");
                string command = commands[0];
                string town = commands[1];

                if (command == "Plunder")
                {
                    int population = int.Parse(commands[2]);
                    int gold = int.Parse(commands[3]);

                    if (townData.ContainsKey(town))
                    {
                        townData[town][0] -= population;
                        townData[town][1] -= gold;
                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {population} citizens killed.");
                        if ((townData[town][0] <= 0) || (townData[town][1] <= 0))
                        {
                            townData.Remove(town);
                            Console.WriteLine($"{town} has been wiped off the map!");
                        }
                    }
                }
                else if (command == "Prosper")
                {
                    int gold = int.Parse(commands[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                    }
                    else
                    {
                        if (townData.ContainsKey(town))
                        {
                            townData[town][1] += gold;
                            Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {townData[town][1]} gold.");
                        }
                    }
                }
            }

            Console.WriteLine($"Ahoy, Captain! There are {townData.Count} wealthy settlements to go to:");
            foreach (var keyValuePair in townData
                .OrderByDescending(x => x.Value[1])
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{keyValuePair.Key} -> Population: {keyValuePair.Value[0]} citizens, Gold: {keyValuePair.Value[1]} kg");
            }
        }
    }
}

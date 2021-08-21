using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, int> plantsRarity = new Dictionary<string, int>();
            Dictionary<string, List<int>> plantsRating = new Dictionary<string, List<int>>();

            for (int i = 1; i <= number; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("<->");
                string plant = input[0];
                int rarity = int.Parse(input[1]);

                if (plantsRarity.ContainsKey(plant))
                {
                    plantsRarity[plant] = rarity;
                }
                else
                {
                    plantsRarity.Add(plant, rarity);
                    plantsRating.Add(plant, new List<int>());
                }
            }

            string info = String.Empty;

            while ((info = Console.ReadLine()) != "Exhibition")
            {
                string[] commands = info
                    .Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                string plant = commands[1];
                int rating;

                switch (command)
                {
                    case "Rate":
                        rating = int.Parse(commands[2]);
                        if (plantsRating.ContainsKey(plant))
                        {
                            plantsRating[plant].Add(rating);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Update":
                        int rarity = int.Parse(commands[2]);
                        if (plantsRarity.ContainsKey(plant))
                        {
                            plantsRarity[plant] = rarity;
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Reset":
                        if (plantsRating.ContainsKey(plant))
                        {
                            plantsRating[plant].Clear();
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }

            Console.WriteLine("Plants for the exhibition:");
            Dictionary<string, List<double>> plants = new Dictionary<string, List<double>>();
            foreach (var keyValuePair in plantsRarity)
            {

                plants.Add(keyValuePair.Key, new List<double>(){ keyValuePair.Value });
                double averageRating = 0;
                if (plantsRating[keyValuePair.Key].Count > 0)
                {
                    averageRating = plantsRating[keyValuePair.Key].Average();
                }

                plants[keyValuePair.Key].Add(averageRating);
            }

            foreach (var keyValuePair in plants
                .OrderByDescending(x=>x.Value[0])
                .ThenByDescending(x=>x.Value[1]))
            {
                Console.WriteLine($"- {keyValuePair.Key}; Rarity: {keyValuePair.Value[0]:F0}; Rating: {keyValuePair.Value[1]:F2}");
            }
        }
    }
}

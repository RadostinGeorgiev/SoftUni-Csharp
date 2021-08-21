using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>()
            {
                {"shards", 0},
                {"fragments", 0},
                {"motes", 0}
            };
            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();
            bool isObtained = false;

            while (!isObtained)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (var i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();

                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        keyMaterials[material] += quantity;

                        if (keyMaterials[material] >= 250)
                        {
                            keyMaterials[material] -= 250;

                            string legendaryItem = string.Empty;
                            if (material == "shards")
                                legendaryItem = "Shadowmourne";
                            else if (material == "fragments")
                                legendaryItem = "Valanyr";
                            else if (material == "motes") legendaryItem = "Dragonwrath";

                            Console.WriteLine($"{legendaryItem} obtained!");
                            isObtained = true;
                            break;
                        }
                    }
                    else
                    {
                        if (junkMaterials.ContainsKey(material))
                        {
                            junkMaterials[material] += quantity;
                        }
                        else
                        {
                            junkMaterials.Add(material, quantity);
                        }
                    }
                }
            }

            foreach (var keyValuePair in keyMaterials
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value}");
            }

            foreach (var keyValuePair in junkMaterials
                .OrderBy(x => x.Key))
            {
                Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value}");
            }
        }
    }
}

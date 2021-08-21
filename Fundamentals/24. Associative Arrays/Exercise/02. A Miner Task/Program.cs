using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();
            string input = Console.ReadLine();

            while (input != "stop")
            {
                string typeOfResource = input;
                int quantity = int.Parse(Console.ReadLine());

                if (resources.ContainsKey(typeOfResource))
                {
                    resources[typeOfResource] += quantity;
                }
                else
                {
                    resources.Add(typeOfResource, quantity);
                }
                
                input = Console.ReadLine();
            }

            foreach (var keyValuePair in resources)
            {
                Console.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value}");
            }
        }
    }
}

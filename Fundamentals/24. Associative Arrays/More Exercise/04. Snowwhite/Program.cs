using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dwarfs = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "Once upon a time")
            {
                string[] info = input.Split(" <:> ");
                string dwarfName = info[0];
                string dwarfHatColor = info[1];
                int dwarfPhysics = int.Parse(info[2]);

                if (dwarfs.ContainsKey(dwarfHatColor))
                {
                    if (dwarfs[dwarfHatColor].ContainsKey(dwarfName))
                    {
                        if (dwarfs[dwarfHatColor][dwarfName] < dwarfPhysics)
                        {
                            dwarfs[dwarfHatColor][dwarfName] = dwarfPhysics;
                        }
                    }
                    else
                    {
                        dwarfs[dwarfHatColor].Add(dwarfName, dwarfPhysics);
                    }
                }
                else
                {
                    dwarfs.Add(dwarfHatColor, new Dictionary<string, int>() { { dwarfName, dwarfPhysics } });
                }

                input = Console.ReadLine();
            }

            Dictionary<string, int> sortedDwarfs = new Dictionary<string, int>();

            foreach (var keyValuePair in dwarfs.OrderByDescending(x => x.Value.Count))
            {
                foreach (var valuePair in keyValuePair.Value)
                {
                    sortedDwarfs.Add($"({keyValuePair.Key}) {valuePair.Key} <-> ", valuePair.Value);
                }
            }

            foreach (var keyValuePair in sortedDwarfs.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{keyValuePair.Key}{keyValuePair.Value}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _04._Snowwhite__2_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dwarf> dwarfts = new List<Dwarf>();
            string input = Console.ReadLine();
            while (input != "Once upon a time")
            {
                string[] info = input.Split(" <:> ");
                string dwarfName = info[0];
                string dwarfHatColor = info[1];
                int dwarfPhysics = int.Parse(info[2]);

                Dwarf dwarf = new Dwarf(dwarfName, dwarfHatColor, dwarfPhysics);

                if (dwarfts.Any(x => x.Name == dwarfName && x.Color == dwarfHatColor))
                {
                    var currentDwarf = dwarfts.First(x => x.Name == dwarfName && x.Color == dwarfHatColor);
                    currentDwarf.Physics = Math.Max(currentDwarf.Physics, dwarfPhysics);
                }
                else
                {
                    dwarfts.Add(dwarf);
                }

                input = Console.ReadLine();
            }

            foreach (var dwarft in dwarfts
                .OrderByDescending(x => x.Physics)
                .ThenByDescending(x => dwarfts.Count(c => x.Color == c.Color)))
            {
                Console.WriteLine($"({dwarft.Color}) {dwarft.Name} <-> {dwarft.Physics}");
            }
        }

        class Dwarf
        {
            public string Name { get; set; }
            public string Color { get; set; }
            public int Physics { get; set; }

            public Dwarf(string name, string color, int physics)
            {
                Name = name;
                Color = color;
                Physics = physics;
            }
        }
    }
}

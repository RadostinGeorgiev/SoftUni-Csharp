using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Nascar_Qualifications
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> racers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                string racer = commands[1];

                switch (command)
                {
                    case "Race":
                        if (!racers.Contains(racer))
                        {
                            racers.Add(racer);
                        }
                        break;
                    case "Accident":
                        if (racers.Contains(racer))
                        {
                            racers.Remove(racer);
                        }
                        break;
                    case "Box":
                        if (racers.Contains(racer))
                        {
                            int index = racers.IndexOf(racer);
                            racers.Remove(racer);
                            racers.Insert(index + 1, racer);
                        }
                        break;
                    case "Overtake":
                        int racersCount = int.Parse(commands[2]);

                        if (racers.Contains(racer))
                        {
                            int index = racers.IndexOf(racer);
                            if (index - racersCount >= 0)
                            {
                                index -= racersCount;
                                racers.Remove(racer);
                                racers.Insert(index, racer);
                            }
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join('~', racers));
        }
    }
}

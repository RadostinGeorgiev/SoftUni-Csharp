using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = commands[0];
                int index = int.Parse(commands[1]);

                switch (command)
                {
                    case "Shoot":
                        int power = int.Parse(commands[2]);

                        if (index >= 0 & index < targets.Count)
                        {
                            targets[index] -= power;
                            if (targets[index] <= 0)
                            {
                                targets.RemoveAt(index);
                            }
                        }
                        break;
                    case "Add":
                        int value = int.Parse(commands[2]);
                        if (index >= 0 & index < targets.Count)
                        {
                            targets.Insert(index, value);
                        }
                        else
                        {
                            Console.WriteLine("Invalid placement!");
                        }
                        break;
                    case "Strike":
                        int radius = int.Parse(commands[2]);
                        if ((index - radius >= 0) && (index + radius < targets.Count))
                        {
                            targets.RemoveRange(index - radius, 2 * radius + 1);
                        }
                        else
                        {
                            Console.WriteLine("Strike missed!");
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join('|', targets));
        }
    }
}

using System;
using System.Collections.Generic;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();

            for (int i = 1; i <= numberOfCommands; i++)
            {
                string[] commands = Console.ReadLine().Split();
                string guest = commands[0];
                string command = commands[2];

                if (command == "going!")
                {
                    if (guests.Contains(guest))
                    {
                        Console.WriteLine($"{guest} is already in the list!");
                    }
                    else
                    {
                        guests.Add(guest);
                    }
                }
                else
                {
                    if (!guests.Contains(guest))
                    {
                        Console.WriteLine($"{guest} is not in the list!");
                    }
                    else
                    {
                        guests.Remove(guest);
                    }
                }

            }

            foreach (var item in guests)
            {
                Console.WriteLine(item);
            }
        }
    }
}

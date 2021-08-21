using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> neighborhood = Console.ReadLine()
                .Split("@", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();
            int houseIndex = 0;

            while (input != "Love!")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                int lenght = int.Parse(commands[1]);
                houseIndex += lenght;
                if (houseIndex > neighborhood.Count - 1)
                {
                    houseIndex = 0;
                }

                if (neighborhood[houseIndex] == 0)
                {
                    Console.WriteLine($"Place {houseIndex} already had Valentine's day.");
                }
                else
                {
                    neighborhood[houseIndex] -= 2;
                    if (neighborhood[houseIndex] == 0)
                    {
                        Console.WriteLine($"Place {houseIndex} has Valentine's day.");
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {houseIndex}.");

            int failedHousesCounter = 0;
            foreach (var house in neighborhood)
            {
                if (house != 0)
                {
                    failedHousesCounter++;
                }
            }

            if (failedHousesCounter == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {failedHousesCounter} places.");
            }
        }
    }
}

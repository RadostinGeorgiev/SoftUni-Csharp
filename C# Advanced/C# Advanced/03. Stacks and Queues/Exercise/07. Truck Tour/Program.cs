using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumps = int.Parse(Console.ReadLine());
            Queue<int> truckFuel = new Queue<int>();

            for (int i = 0; i < pumps; i++)
            {
                int[] pupmpData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                int availableFuel = pupmpData[0] - pupmpData[1];
                truckFuel.Enqueue(availableFuel);
            }

            int startPumpIndex = 0;
            int totalFuel = 0;
            while (totalFuel <= 0)
            {
                foreach (var availableFuel in truckFuel)
                {
                    totalFuel += availableFuel;
                    if (totalFuel < 0)
                    {
                        truckFuel.Enqueue(truckFuel.Dequeue());
                        startPumpIndex++;
                        totalFuel = 0;
                        break;
                    }
                }
            }

            Console.WriteLine(startPumpIndex);
        }
    }
}

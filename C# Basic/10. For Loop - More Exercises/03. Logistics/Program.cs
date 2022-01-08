using System;

namespace _03._Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            const int busCargoPrice = 200;
            const int truckCargoPrice = 175;
            const int trainCargoPrice = 120;

            int numberCargo = int.Parse(Console.ReadLine());

            int totalWeight = 0;
            int weightByBus = 0;
            int weightByTruck = 0;
            int weightByTrain = 0;


            for (int i = 0; i < numberCargo; i++)
            {
                int weightCargo = int.Parse(Console.ReadLine());

                totalWeight += weightCargo;

                if (weightCargo <= 3)
                {
                    weightByBus += weightCargo;
                }
                else if (weightCargo <= 11)
                {
                    weightByTruck += weightCargo;
                }
                else
                {
                    weightByTrain += weightCargo;
                }
            }

            int totalCosts = weightByBus * busCargoPrice +
                             weightByTruck * truckCargoPrice +
                             weightByTrain * trainCargoPrice;

            Console.WriteLine($"{1.0 * totalCosts / totalWeight:F2}");
            Console.WriteLine($"{1.0 * weightByBus / totalWeight * 100:F2}%");
            Console.WriteLine($"{1.0 * weightByTruck / totalWeight * 100:F2}%");
            Console.WriteLine($"{1.0 * weightByTrain / totalWeight * 100:F2}%");
        }
    }
}
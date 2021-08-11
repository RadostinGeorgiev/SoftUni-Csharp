using System;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitsPerWorker = int.Parse(Console.ReadLine());
            int countOfWorkers = int.Parse(Console.ReadLine());
            int totalBiscuitsAmount = int.Parse(Console.ReadLine());

            double totalProduction = 0;

            for (int i = 1; i <= 30; i++)
            {
                double dayEfficiency = 1;
                if (i % 3 == 0)
                {
                    dayEfficiency = 0.75;
                }
                totalProduction += Math.Floor(biscuitsPerWorker * countOfWorkers * dayEfficiency);
            }

            Console.WriteLine($"You have produced {totalProduction} biscuits for the past month.");
            if (totalProduction > totalBiscuitsAmount)
            {
                Console.WriteLine($"You produce {(totalProduction - totalBiscuitsAmount) / totalBiscuitsAmount * 100:F2} percent more biscuits.");
            }
            else if (totalProduction < totalBiscuitsAmount)
            {
                Console.WriteLine($"You produce {(totalBiscuitsAmount - totalProduction) / totalBiscuitsAmount * 100:F2} percent less biscuits.");
            }
        }
    }
}

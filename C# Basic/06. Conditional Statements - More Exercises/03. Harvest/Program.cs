using System;

namespace Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int squireVines = int.Parse(Console.ReadLine());
            double extractionGrapes = double.Parse(Console.ReadLine());
            int necessaryWine = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double wineArea = squireVines * 0.4;
            double producedGrapes = wineArea * extractionGrapes;
            double producedWine = producedGrapes / 2.5;
            double restWine = producedWine - necessaryWine;

            if (restWine <0)
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(Math.Abs(restWine))} liters wine needed.");
            else
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(producedWine)} liters.");
                Console.WriteLine($"{Math.Ceiling(restWine)} liters left -> {Math.Ceiling(restWine/workers)} liters per person.");
            }
        }
    }
}
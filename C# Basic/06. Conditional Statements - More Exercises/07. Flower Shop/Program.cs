using System;

namespace Flower_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            const double priceMagnolias = 3.25;
            const double priceHyacinths = 4;
            const double priceRoses = 3.5;
            const double priceCactus = 8;

            int numMagnolias = int.Parse(Console.ReadLine());
            int numHyacinths = int.Parse(Console.ReadLine());
            int numRoses = int.Parse(Console.ReadLine());
            int numCactus = int.Parse(Console.ReadLine());
            double priceGift = double.Parse(Console.ReadLine());

            double totalValue = numMagnolias * priceMagnolias + numHyacinths * priceHyacinths + numRoses * priceRoses + numCactus * priceCactus;
            totalValue *= 0.95;
            double restMoney = totalValue - priceGift;

            Console.WriteLine(restMoney >= 0
                ? $"She is left with {Math.Floor(restMoney)} leva."
                : $"She will have to borrow {Math.Floor(Math.Abs(restMoney))} leva.");
        }
    }
}
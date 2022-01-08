using System;

namespace _06._Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceMackerel = double.Parse(Console.ReadLine());
            double priceToy = double.Parse(Console.ReadLine());
            double weightBonito = double.Parse(Console.ReadLine());
            double weightHorseMackerel = double.Parse(Console.ReadLine());
            int weightMussels = int.Parse(Console.ReadLine());

            double priceBonito = priceMackerel * 1.6;
            double priceHorseMackerel = priceToy * 1.8;
            const double priceMussels = 7.5;

            double totalValue = weightBonito * priceBonito + weightHorseMackerel * priceHorseMackerel + weightMussels * priceMussels;

            Console.WriteLine($"{totalValue:F2}");
        }
    }
}
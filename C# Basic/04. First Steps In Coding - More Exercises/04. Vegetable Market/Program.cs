using System;

namespace _04._Vegetable_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceVegetables = double.Parse(Console.ReadLine());
            double priceFruits = double.Parse(Console.ReadLine());
            int weightVegetables = int.Parse(Console.ReadLine());
            int weightFruits = int.Parse(Console.ReadLine());

            double totalPrice = (weightVegetables * priceVegetables + weightFruits * priceFruits) / 1.94;

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
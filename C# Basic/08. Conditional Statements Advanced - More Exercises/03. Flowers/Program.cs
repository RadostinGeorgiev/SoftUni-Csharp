using System;

namespace _03._Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            int chrysanthemums = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int tulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            char holiday = char.Parse(Console.ReadLine());

            double priceChrysanthemums = 0;
            double priceRoses = 0;
            double priceTulips = 0;

            switch (season)
            {
                case "Spring":
                case "Summer":
                    priceChrysanthemums = 2.0;
                    priceRoses = 4.10;
                    priceTulips = 2.50;
                    break;

                case "Autumn":
                case "Winter":
                    priceChrysanthemums = 3.75;
                    priceRoses = 4.50;
                    priceTulips = 4.15;
                    break;
            }

            double totalPrice = chrysanthemums * priceChrysanthemums + roses * priceRoses + tulips * priceTulips;

            if (holiday == 'Y')
                totalPrice += totalPrice * 0.15;

            if (tulips > 7 && season == "Spring")
                totalPrice -= totalPrice * 0.05;

            if (roses >= 10 && season == "Winter")
                totalPrice -= totalPrice * 0.1;

            if (chrysanthemums + roses + tulips > 20)
                totalPrice -= totalPrice * 0.2;

            totalPrice += 2;

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
using System;

namespace _04._Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermen = int.Parse(Console.ReadLine());

            const int boatRentSpring = 3000;
            const int boatRentSummerAndAutumn = 4200;
            const int boatRentWinter = 2600;
            double discount;

            if (fishermen <= 6)
                discount = 0.1;
            else if (fishermen <= 11)
                discount = 0.15;
            else
                discount = 0.25;

            double totalCosts = season switch
            {
                "Spring" => boatRentSpring * (1 - discount),
                "Summer" => boatRentSummerAndAutumn * (1 - discount),
                "Autumn" => boatRentSummerAndAutumn * (1 - discount),
                "Winter" => boatRentWinter * (1 - discount),
                _ => 0.00
            };

            if (fishermen % 2 == 0 && season != "Autumn")
            {
                totalCosts -= totalCosts * 0.05;
            }

            Console.WriteLine(budget >= totalCosts
                ? $"Yes! You have {budget - totalCosts:F2} leva left."
                : $"Not enough money! You need {totalCosts - budget:F2} leva.");
        }
    }
}

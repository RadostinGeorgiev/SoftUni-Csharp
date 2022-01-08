using System;

namespace _05._Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string country = "";
            string place = "";
            double totalCosts = 0.00;

            if (budget <= 100)
            {
                country = "Bulgaria";
                if (season == "summer")
                {
                    place = "Camp";
                    totalCosts = budget * 0.3;
                }
                else
                {
                    place = "Hotel";
                    totalCosts = budget * 0.7;
                }
            }
            else if (budget > 1000)
            {
                country = "Europe";
                place = "Hotel";
                totalCosts = budget * 0.9;
            }
            else
            {
                country = "Balkans";
                if (season == "summer")
                {
                    place = "Camp";
                    totalCosts = budget * 0.4;
                }
                else
                {
                    place = "Hotel";
                    totalCosts = budget * 0.8;
                }
            }

            Console.WriteLine($"Somewhere in {country}");
            Console.WriteLine($"{place} - {totalCosts:F2}");
        }
    }
}
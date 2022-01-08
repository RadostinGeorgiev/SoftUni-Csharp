using System;

namespace _01._Match_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            const double priceVIP = 499.99;
            const double priceNormal = 249.99;

            double budget = double.Parse(Console.ReadLine());
            string peoplesCategory = Console.ReadLine();
            int peoples = int.Parse(Console.ReadLine());

            double transportCosts;

            if (peoples <= 4)
                transportCosts = budget * 0.75;
            else if (peoples <= 9)
                transportCosts = budget * 0.6;
            else if (peoples <= 24)
                transportCosts = budget * 0.5;
            else if (peoples <= 49)
                transportCosts = budget * 0.4;
            else
                transportCosts = budget * 0.25;

            double restOfMoney = budget - transportCosts;

            double totalPriceTickets;
            if (peoplesCategory == "VIP")
                totalPriceTickets = peoples * priceVIP;
            else
                totalPriceTickets = peoples * priceNormal;

            Console.WriteLine(restOfMoney >= totalPriceTickets
                ? $"Yes! You have {restOfMoney - totalPriceTickets:F2} leva left."
                : $"Not enough money! You need {totalPriceTickets - restOfMoney:F2} leva.");
        }
    }
}
using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            const double puzzlesPrice = 2.60;
            const double dollyPrice = 3.00;
            const double bearsPrice = 4.10;
            const double minionsPrice = 8.20;
            const double lorryPrice = 2.00;

            double excursionPrice = double.Parse(Console.ReadLine());
            int numPuzzles = int.Parse(Console.ReadLine());
            int dolly = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int lorry = int.Parse(Console.ReadLine());

            double totalAmount = (numPuzzles * puzzlesPrice) + (dolly * dollyPrice) + (bears * bearsPrice) + (minions * minionsPrice) + (lorry * lorryPrice);
            int toys = numPuzzles + dolly + bears + minions + lorry;

            if (toys >= 50)
            {
                totalAmount -= totalAmount * 0.25;
            }

            double loan = totalAmount * 0.1;
            double rest = totalAmount - loan - excursionPrice;

            Console.WriteLine(rest >= 0 
                ? $"Yes! {rest:F2} lv left." 
                : $"Not enough money! {-rest:F2} lv needed.");
        }
    }
}
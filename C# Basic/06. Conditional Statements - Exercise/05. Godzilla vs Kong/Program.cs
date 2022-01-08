using System;

namespace Godzilla_vs_Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int superActor = int.Parse(Console.ReadLine());
            double dressPrice = double.Parse(Console.ReadLine());

            double decorAmount = budget * 0.1;
            double dressAmount = superActor * dressPrice;

            if (superActor > 150)
            {
                dressAmount -= dressAmount * 0.1;
            }
            double totalAmount = decorAmount + dressAmount;

            if (totalAmount > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {(totalAmount - budget):F2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {(budget - totalAmount):F2} leva left.");
            }
        }
    }
}
using System;

namespace _02._Report_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int necessaryMoney = int.Parse(Console.ReadLine());

            int payments = 0;
            int totalMoneyByCash = 0;
            int totalMoneyByCard = 0;
            int paymentsByCash = 0;
            int paymentsByCard = 0;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                int currentPrice = int.Parse(command);
                payments++;

                if (payments % 2 == 0)
                {
                    if (currentPrice < 10)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                        totalMoneyByCard += currentPrice;
                        paymentsByCard++;
                    }
                }
                else
                {
                    if (currentPrice > 100)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                        totalMoneyByCash += currentPrice;
                        paymentsByCash++;
                    }
                }

                if (totalMoneyByCash + totalMoneyByCard >= necessaryMoney)
                {
                    Console.WriteLine($"Average CS: {(double)totalMoneyByCash / paymentsByCash:F2}");
                    Console.WriteLine($"Average CC: {(double)totalMoneyByCard / paymentsByCard:F2}");
                    return;
                }
            }

            Console.WriteLine("Failed to collect required money for charity.");
        }
    }
}
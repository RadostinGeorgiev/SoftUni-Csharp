using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            string payment = Console.ReadLine();
            double total = 0.00;

            while (payment != "NoMoreMoney")
            {
                double currentPayment = double.Parse(payment);

                if (currentPayment < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                Console.WriteLine($"Increase: {currentPayment:F2}");
                total += currentPayment;
                payment = Console.ReadLine();
            }

            Console.WriteLine($"Total: {total:F2}");
        }
    }
}
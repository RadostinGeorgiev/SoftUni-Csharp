using System;

namespace DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyDeposit = double.Parse(Console.ReadLine());
            int numMonths = int.Parse(Console.ReadLine());
            double interestRate = double.Parse(Console.ReadLine());
            double interest = moneyDeposit * interestRate / 100;
            double monthsInterest = interest / 12;
            double totalAmount = moneyDeposit + (numMonths * monthsInterest);

            Console.WriteLine($"{totalAmount:F2}");
        }
    }
}
using System;

namespace _04._Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceLaundry = double.Parse(Console.ReadLine());
            double priceToys = double.Parse(Console.ReadLine());

            int numberToys = 0;
            double totalMoney = 0.00;
            int moneyInCurrentYear = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    totalMoney += 10 + moneyInCurrentYear;
                    moneyInCurrentYear += 10;
                    totalMoney--;
                }
                else
                {
                    numberToys++;
                }
            }

            totalMoney += numberToys * priceToys;

            Console.WriteLine(totalMoney >= priceLaundry
                ? $"Yes! {totalMoney - priceLaundry:F2}"
                : $"No! {priceLaundry - totalMoney:F2}");
        }
    }
}
using System;

namespace _01._Back_To_The_Past
{
    class Program
    {
        static void Main(string[] args)
        {
            double bequest = double.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            double restMoney = bequest;

            for (int i = 0; i <= year - 1800; i++)
            {
                restMoney -= 12000;

                if (i % 2 != 0)
                {
                    restMoney -= 50 * (i + 18);
                }
            }

            Console.WriteLine(restMoney >= 0
                ? $"Yes! He will live a carefree life and will have {restMoney:F2} dollars left."
                : $"He will need {Math.Abs(restMoney):f2} dollars to survive.");
        }
    }
}
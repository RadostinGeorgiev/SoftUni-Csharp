using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyForExcursion = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());

            int totalDays = 0;
            int currentSpend = 0;

            while (availableMoney < moneyForExcursion && currentSpend < 5)
            {
                string action = Console.ReadLine();
                double currentSum = double.Parse(Console.ReadLine());
                totalDays++;

                switch (action)
                {
                    case "spend":
                    {
                        currentSpend++;
                        if (currentSpend == 5)
                        {
                            Console.WriteLine("You can't save the money.");
                            Console.WriteLine($"{totalDays}");
                        }

                        availableMoney -= currentSum;

                        if (availableMoney < 0)
                        {
                            availableMoney = 0;
                        }
                        break;
                    }

                    case "save":
                        currentSpend = 0;
                        availableMoney += currentSum;
                        break;
                }
            }

            if (availableMoney >= moneyForExcursion)
            {
                Console.WriteLine($"You saved the money for {totalDays} days.");
            }
        }
    }
}
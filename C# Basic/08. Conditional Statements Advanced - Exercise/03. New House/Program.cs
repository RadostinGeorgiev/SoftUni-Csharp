using System;

namespace _03._New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            const double priceOfRoses = 5;
            const double priceOfDahlias = 3.8;
            const double priceOfTulips = 2.8;
            const double priceOfNarcissus = 3;
            const double priceOfGladiolus = 2.5;

            string typeOfFlowers = Console.ReadLine();
            int numberOfFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double totalCosts = 0.00;

            switch (typeOfFlowers)
            {
                case "Roses":
                    totalCosts = numberOfFlowers * priceOfRoses;

                    if (numberOfFlowers > 80)
                        totalCosts -= totalCosts * 0.1;
                    break;

                case "Dahlias":
                    totalCosts = numberOfFlowers * priceOfDahlias;

                    if (numberOfFlowers > 90)
                        totalCosts -= totalCosts * 0.15;
                    break;

                case "Tulips":
                    totalCosts = numberOfFlowers * priceOfTulips;

                    if (numberOfFlowers > 80)
                        totalCosts -= totalCosts * 0.15;
                    break;

                case "Narcissus":
                    totalCosts = numberOfFlowers * priceOfNarcissus;

                    if (numberOfFlowers < 120)
                        totalCosts += totalCosts * 0.15;
                    break;

                case "Gladiolus":
                    totalCosts = numberOfFlowers * priceOfGladiolus;

                    if (numberOfFlowers < 80)
                        totalCosts += totalCosts * 0.20;
                    break;
            }

            double restOfMoney = budget - totalCosts;

            Console.WriteLine(restOfMoney >= 0
                ? $"Hey, you have a great garden with {numberOfFlowers} {typeOfFlowers} and {restOfMoney:F2} leva left."
                : $"Not enough money, you need {Math.Abs(restOfMoney):F2} leva more.");
        }
    }
}
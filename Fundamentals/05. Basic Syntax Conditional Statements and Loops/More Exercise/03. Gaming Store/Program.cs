using System;

namespace _03._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentMoney = double.Parse(Console.ReadLine());
            string nameOfGame = Console.ReadLine();
            double spentMoney = 0.0;

            while (nameOfGame != "Game Time")
            {
                double price = 0.00;

                switch (nameOfGame)
                {
                    case "OutFall 4":
                        price = 39.99;
                        break;
                    case "CS: OG":
                        price = 15.99;
                        break;
                    case "Zplinter Zell":
                        price = 19.99;
                        break;
                    case "Honored 2":
                        price = 59.99;
                        break;
                    case "RoverWatch":
                        price = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        price = 39.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        nameOfGame = Console.ReadLine();
                        continue;
                }

                if (currentMoney >= price)
                {
                    currentMoney -= price;
                    spentMoney += price;
                    Console.WriteLine($"Bought {nameOfGame}");
                }
                else
                {
                    Console.WriteLine("Too Expensive");
                }

                if (currentMoney == 0.0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }

                nameOfGame = Console.ReadLine();
            }

            if (currentMoney != 0.0)
                Console.WriteLine($"Total spent: ${spentMoney:f2}. Remaining: ${currentMoney:f2}");
        }
    }
}
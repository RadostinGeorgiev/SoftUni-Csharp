using System;
using System.Threading.Channels;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double moneySum = 0.00;

            while (input != "Start")
            {
                double coin = double.Parse(input);

                if (coin != 0.1 && coin != 0.2 && coin != 0.5 && coin != 1 && coin != 2)
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }
                else
                {
                    moneySum += coin;
                }

                input = Console.ReadLine();
            }

            string productName = Console.ReadLine();

            while (productName != "End")
            {

                double price = 0.0;
                switch (productName)
                {
                    case "Nuts":
                        price = 2.0;
                        break;
                    case "Water":
                        price = 0.7;
                        break;
                    case "Crisps":
                        price = 1.5;
                        break;
                    case "Soda":
                        price = 0.8;
                        break;
                    case "Coke":
                        price = 1.0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }

                if (price != 0)
                {
                    if (price <= moneySum)
                    {
                        moneySum -= price;
                        Console.WriteLine($"Purchased {productName.ToLower()}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }

                }

                productName = Console.ReadLine();
            }

            Console.WriteLine($"Change: {moneySum:f2}");
        }
    }
}

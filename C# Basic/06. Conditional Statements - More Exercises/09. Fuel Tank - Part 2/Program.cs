using System;

namespace Fuel_Tank_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfFuel = Console.ReadLine(); //"Gas", "Gasoline", "Diesel"
            double chargedFuel = double.Parse(Console.ReadLine());
            string clubCard = Console.ReadLine();//"Yes", "No"

            const double priceGasoline = 2.22;
            const double priceDiesel = 2.33;
            const double priceGas = 0.93;

            double discount = 0.00;
            double totalValue = 0.00;

            switch (typeOfFuel)
            {
                case "Gasoline":
                    if (clubCard == "Yes")
                    {
                        discount = 0.18;
                    }

                    totalValue = chargedFuel * (priceGasoline - discount);
                    break;
                case "Diesel":
                    if (clubCard == "Yes")
                    {
                        discount = 0.12;
                    }

                    totalValue = chargedFuel * (priceDiesel - discount);
                    break;
                case "Gas":
                    if (clubCard == "Yes")
                    {
                        discount = 0.08;
                    }

                    totalValue = chargedFuel * (priceGas - discount);
                    break;
            }

            if (chargedFuel < 20)
            {
                discount = 0.00;
            }
            else if (chargedFuel > 25)
            {
                discount = 0.1;
            }
            else
            {
                discount = 0.08;
            }

            totalValue -= totalValue * discount;
            Console.WriteLine($"{totalValue:F2} lv.");
        }
    }
}
using System;

namespace Fuel_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfFuel = Console.ReadLine(); //"Gas", "Gasoline", "Diesel"
            double chargedFuel = double.Parse(Console.ReadLine());

            switch (typeOfFuel)
            {
                case "Gas":
                case "Gasoline":
                case "Diesel":
                    Console.WriteLine(chargedFuel >= 25
                        ? $"You have enough {typeOfFuel.ToLower()}."
                        : $"Fill your tank with {typeOfFuel.ToLower()}!");
                    break;
                default:
                    Console.WriteLine("Invalid fuel!");
                    break;
            }
        }
    }
}
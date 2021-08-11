using System;

namespace _01._Computer_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double totalPrice = 0;

            while ((input != "special") && (input != "regular"))
            {
                double price = double.Parse(input);
                if (price < 0)
                {
                    Console.WriteLine($"Invalid price!");
                    input = Console.ReadLine();
                    continue;
                }

                totalPrice += price;

                input = Console.ReadLine();
            }

            double discount = 1;
            if (input == "special")
            {
                discount = 0.9;
            }

            if (totalPrice == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPrice:F2}" + "$");
                Console.WriteLine($"Taxes: {totalPrice * 0.2:F2}" + "$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalPrice * 1.2 * discount:F2}" + "$");
            }

        }
    }
}

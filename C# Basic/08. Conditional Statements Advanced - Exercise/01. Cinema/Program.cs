using System;

namespace _01._Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            double totalIncome = type switch
            {
                "Premiere" => rows * columns * 12,
                "Normal" => rows * columns * 7.5,
                "Discount" => rows * columns * 5,
                _ => 0.00
            };

            Console.WriteLine($"{totalIncome:f2} leva");
        }
    }
}
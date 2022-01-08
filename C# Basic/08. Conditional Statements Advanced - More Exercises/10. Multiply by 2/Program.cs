using System;

namespace _10._Multiply_by_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double number;
            while ((number = double.Parse(Console.ReadLine())) >= 0)
            {
                Console.WriteLine($"Result: {number * 2:F2}");
            }

            Console.WriteLine("Negative number!");
        }
    }
}
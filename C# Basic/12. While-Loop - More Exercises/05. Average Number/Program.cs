using System;

namespace _05._Average_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            double average = 0.0;

            for (int i = 0; i < number; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                average += currentNumber;
            }

            average /= number;
            Console.WriteLine($"{average:F2}");
        }
    }
}
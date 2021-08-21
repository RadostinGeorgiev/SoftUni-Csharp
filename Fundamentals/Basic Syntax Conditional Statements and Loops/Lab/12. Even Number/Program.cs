using System;

namespace _12._Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool isOdd = number % 2 != 0;

            while (isOdd)
            {
                Console.WriteLine("Please write an even number.");
                number = int.Parse(Console.ReadLine());
                isOdd = number % 2 != 0;
            }

            Console.WriteLine($"The number is: {Math.Abs(number)}");
        }
    }
}

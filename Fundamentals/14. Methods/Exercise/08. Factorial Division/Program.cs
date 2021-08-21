using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine($"{(decimal)Factorial(firstNumber) / Factorial(secondNumber):f2}");
        }

        static decimal Factorial(int input)
        {
            decimal result = 1;
            for (int i = 1; i <= input; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}

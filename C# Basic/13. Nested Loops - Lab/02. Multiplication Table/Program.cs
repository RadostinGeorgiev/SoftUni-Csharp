using System;

namespace _02._Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int number1 = 1; number1 <= 10; number1++)
            {
                for (int number2 = 1; number2 <= 10; number2++)
                {
                    Console.WriteLine($"{number1} * {number2} = {number1 * number2}");
                }
            }
        }
    }
}
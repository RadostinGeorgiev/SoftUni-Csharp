using System;

namespace _01._Sign_of_Integer_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine($"The number {number} is {CheckIntegerSign(number)}.");
        }

        static string CheckIntegerSign(int input)
        {
            if (input > 0)
            {
                return "positive";
            }
            else if (input < 0)
            {
                return "negative";
            }
            else
            {
                return "zero";
            }
        }

    }
}

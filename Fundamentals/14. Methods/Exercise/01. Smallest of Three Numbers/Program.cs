using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            Console.WriteLine(GetMinNumber(number1, number2, number3));
        }

        static int GetMinNumber(int input1, int input2, int input3)
        {
            return Math.Min(Math.Min(input1, input2), input3);
        }
    }
}

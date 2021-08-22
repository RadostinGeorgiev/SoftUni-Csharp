using System;

namespace _05._Multiplication_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            if (number1 == 0 || number2 == 0 || number3 == 0)
            {
                Console.WriteLine("zero");
            }
            else if (CountNegativ(number1, number2, number3) % 2 != 0)
            {
                Console.WriteLine("negative");
            }
            else
            {
                Console.WriteLine("positive");
            }
        }

        static int CountNegativ(int input1, int input2, int input3)
        {
            int counter = 0;

            if (input1 < 0)
            {
                counter++;
            }

            if (input2 < 0)
            {
                counter++;
            }

            if (input3 < 0)
            {
                counter++;
            }

            return counter;
        }
    }
}

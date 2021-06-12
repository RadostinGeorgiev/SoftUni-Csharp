using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                if (IsTopNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static int SumOfDigits(int input)
        {
            int sum = 0;

            while (input > 0)
            {
                sum += input % 10;
                input /= 10;
            }

            return sum;
        }

        static bool IsContainOdd(int input)
        {
            while (input > 0)
            {
                int currentDigit = input % 10;

                if (currentDigit % 2 != 0)
                {
                    return true;
                }

                input /= 10;
            }

            return false;
        }

        static bool IsTopNumber(int input)
        {
            if ((SumOfDigits(input) % 8 == 0) && (IsContainOdd(input)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

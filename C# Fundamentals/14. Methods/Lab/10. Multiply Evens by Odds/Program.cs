using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMultipleOfEvenAndOdds(Math.Abs(number)));
        }

        static int GetMultipleOfEvenAndOdds(int input)
        {
            return GetSumOfOddOrEvenDigits(input, 0) * GetSumOfOddOrEvenDigits(input, 1);
        }

        static int GetSumOfOddOrEvenDigits(int input, int isOdd)
        {
            int sum = 0;
            while (input > 0)
            {
                int currentDigit = input % 10;
                input /= 10;

                if (currentDigit % 2 == isOdd)
                {
                    sum += currentDigit;
                }
            }

            return sum;
        }
    }
}

using System;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                double result = 0;
                var operandOne = input[i][0];
                var number = double.Parse(input[i].Substring(1, input[i].Length - 2));
                var operandTwo = input[i][input[i].Length - 1];

                if (IsUpperLetter(operandOne))
                {
                    result = number / AlphabetPosition(operandOne);
                }
                else
                {
                    result = number * AlphabetPosition(operandOne);
                }

                if (IsUpperLetter(operandTwo))
                {
                    result -= AlphabetPosition(operandTwo);
                }
                else
                {
                    result += AlphabetPosition(operandTwo);
                }

                sum += result;
            }

            Console.WriteLine($"{sum:F2}");
        }

        static bool IsUpperLetter(char c)
        {
            if (c >= 'A' && c <= 'Z')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static int AlphabetPosition(char c)
        {
            if (IsUpperLetter(c))
            {
                return c - 64;
            }
            else
            {
                return c - 96;
            }


        }
    }
}

using System;

namespace _02._Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            for (int i = number1; i <= number2; i++)
            {
                int oddSum = 0;
                int evenSum = 0;
                string currentNumber = Convert.ToString(i);

                for (int j = 0; j < 6; j++)
                {
                    if (j % 2 != 0)
                        oddSum += Convert.ToInt32(currentNumber[j]);
                    else
                        evenSum += Convert.ToInt32(currentNumber[j]);
                }

                if (oddSum == evenSum) Console.Write($"{i} ");
            }
        }
    }
}
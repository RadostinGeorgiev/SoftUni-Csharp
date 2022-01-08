using System;

namespace _09._Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int firstSum = 0;
            int secondSum = 0;

            for (int i = 0; i < 2 * number; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (i < number)
                    firstSum += currentNumber;
                else
                    secondSum += currentNumber;
            }

            int difference = Math.Abs(firstSum - secondSum);

            Console.WriteLine(difference == 0 ? $"Yes, sum = {firstSum}" : $"No, diff = {difference}");
        }
    }
}
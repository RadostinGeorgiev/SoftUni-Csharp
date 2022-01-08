using System;

namespace _02._Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int maxNumber = int.MinValue;
            int totalSum = 0;

            for (int i = 0; i < number; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber > maxNumber)
                {
                    maxNumber = currentNumber;
                }

                totalSum += currentNumber;
            }

            totalSum -= maxNumber;

            if (maxNumber == totalSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {totalSum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(totalSum - maxNumber)}");
            }
        }
    }
}
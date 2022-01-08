using System;

namespace _10._Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                int number = int.Parse(Console.ReadLine());
                int firstSum = 0;
                int secondSum = 0;

                for (int i = 0; i < number; i++)
                {
                    int currentNumber = int.Parse(Console.ReadLine());

                    if (i % 2 ==0 )
                        firstSum += currentNumber;
                    else
                        secondSum += currentNumber;
                }

                int difference = Math.Abs(firstSum - secondSum);

                if (difference == 0)
                {
                    Console.WriteLine("Yes");
                    Console.WriteLine($"Sum = {firstSum}");
                }
                else
                {
                    Console.WriteLine("No");
                    Console.WriteLine($"Diff = {difference}");
                }
            }
        }
    }
}
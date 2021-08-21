using System;
using System.Linq;

namespace _02._Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            double leftCarTime = 0;
            double rightCarTime = 0;

            for (int i = 0; i < numbers.Length / 2; i++)
            {
                int currentDigit = numbers[i];
                if (currentDigit == 0)
                {
                    leftCarTime *= 0.8;
                }
                else
                {
                    leftCarTime += currentDigit;
                }

                currentDigit = numbers[numbers.Length - 1 - i];
                if (currentDigit == 0)
                {
                    rightCarTime *= 0.8;
                }
                else
                {
                    rightCarTime += currentDigit;
                }
            }

            Console.WriteLine(leftCarTime < rightCarTime ? 
                $"The winner is left with total time: {leftCarTime}" : 
                $"The winner is right with total time: {rightCarTime}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] bomb = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();


            int bombNumber = bomb[0];
            int bombPower = bomb[1];

            while (numbers.Contains(bombNumber))
            {
                int bombPosition = numbers.FindIndex(n => n == bombNumber);

                int startPosition = bombPosition - bombPower;
                if (startPosition < 0)
                {
                    startPosition = 0;
                }

                int endPosition = bombPosition + bombPower;
                if (endPosition > numbers.Count - 1)
                {
                    endPosition = numbers.Count - 1;
                }

                for (int i = startPosition; i <= endPosition; i++)
                {
                    numbers.RemoveAt(startPosition);
                }
            }

            int sum = numbers.Sum();
            Console.WriteLine(sum);
        }
    }
}

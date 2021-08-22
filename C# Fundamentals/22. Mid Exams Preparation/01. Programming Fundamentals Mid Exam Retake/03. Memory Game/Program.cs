using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Memory_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();
            int moviesCounter = 0;
            bool isWin = false;
            while (input != "end")
            {
                int[] indexes = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                moviesCounter++;

                if ((indexes[0] == indexes[1]) || 
                    (indexes[0] < 0) ||
                    (indexes[1] < 0) ||
                    (indexes[0] > numbers.Count - 1) ||
                    (indexes[1] > numbers.Count - 1))
                {
                    numbers.Insert(numbers.Count/2, $"-{moviesCounter}a");
                    numbers.Insert(numbers.Count/2, $"-{moviesCounter}a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    input = Console.ReadLine();
                    continue;
                }

                if (numbers[indexes[0]] == numbers[indexes[1]])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {numbers[indexes[0]]}!");
                    int maxIndex = Math.Max(indexes[0], indexes[1]);
                    int minIndex = Math.Min(indexes[0], indexes[1]);
                    numbers.RemoveAt(maxIndex);
                    numbers.RemoveAt(minIndex);
                }
                else
                {
                    Console.WriteLine("Try again!");
                }

                if (numbers.Count == 0)
                {
                    isWin = true;
                    break;
                }

                input = Console.ReadLine();
            }

            if (isWin)
            {
                Console.WriteLine($"You have won in {moviesCounter} turns!");
            }
            else
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(' ', numbers));
            }
        }
    }
}

namespace _01._Best_Team
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToArray();

            Stack<int> longestIncreasingSubsequence = LIS(sequence);
            Stack<int> longestDecreasingSubsequence = LIS(sequence.Reverse().ToArray());

            Console.WriteLine(longestIncreasingSubsequence.Count() > longestDecreasingSubsequence.Count()
                ? string.Join(" ", longestIncreasingSubsequence)
                : string.Join(" ", longestDecreasingSubsequence.Reverse()));
        }

        private static Stack<int> LIS(int[] sequence)
        {
            int[] lengths = new int[sequence.Length];
            int[] prevs = new int[sequence.Length];

            int bestLength = 0;
            int bestIndex = -1;

            Array.Fill(lengths, 1);
            Array.Fill(prevs, -1);

            for (int current = 0; current < sequence.Length; current++)
            {
                int currentNumber = sequence[current];

                for (int prev = 0; prev < current; prev++)
                {
                    int prevNumber = sequence[prev];

                    if (currentNumber > prevNumber &&
                        lengths[current] < lengths[prev] + 1)
                    {
                        lengths[current] = lengths[prev] + 1;
                        prevs[current] = prev;
                    }
                }

                if (lengths[current] > bestLength)
                {
                    bestLength = lengths[current];
                    bestIndex = current;
                }
            }

            Stack<int> lis = new Stack<int>();                                      //Get LIS

            while (bestIndex != -1)
            {
                lis.Push(sequence[bestIndex]);
                bestIndex = prevs[bestIndex];
            }

            return lis;
        }
    }
}
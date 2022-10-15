namespace _01._Best_Team
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        public static int[,] lengths;
        public static int[,] prevs;

        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            lengths = new int[2, sequence.Length];
            prevs = new int[2, sequence.Length];

            int bestLength = 0;
            int bestIndexRow = -1;
            int bestIndexCol = -1;

            for (int i = 0; i <= 1; i++)
            {
                for (int j = 0; j < sequence.Length; j++)
                {
                    lengths[i, j] = 1;
                    prevs[i, j] = -1;
                }
            }

            for (int current = 0; current < sequence.Length; current++)
            {
                int currentNumber = sequence[current];

                for (int prev = 0; prev < current; prev++)
                {
                    var prevNumber = sequence[prev];

                    if (currentNumber > prevNumber &&
                        lengths[0, current] < lengths[0, prev] + 1)
                    {
                        lengths[0, current] = lengths[0, prev] + 1;
                        prevs[0, current] = prev;
                    }

                    if (currentNumber < prevNumber &&
                        lengths[1, current] <= lengths[1, prev] + 1)
                    {
                        lengths[1, current] = lengths[1, prev] + 1;
                        prevs[1, current] = prev;
                    }
                }

                if (lengths[0, current] > bestLength)
                {
                    bestLength = lengths[0, current];
                    bestIndexRow = 0;
                    bestIndexCol = current;
                }

                if (lengths[1, current] > bestLength)
                {
                    bestLength = lengths[1, current];
                    bestIndexRow = 1;
                    bestIndexCol = current;
                }
            }
            
            Console.WriteLine(string.Join(' ', GetLIS(sequence, prevs, bestIndexRow, bestIndexCol)));
        }

        private static Stack<int> GetLIS(int[] sequence, int[,] prevs, int indexRow, int indexCol)
        {
            Stack<int> lis = new Stack<int>();

            while (indexCol != -1)
            {
                lis.Push(sequence[indexCol]);
                indexCol = prevs[indexRow, indexCol];
            }

            return lis;
        }
    }
}

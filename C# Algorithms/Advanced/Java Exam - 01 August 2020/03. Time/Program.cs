namespace _03._Time
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstSequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] secondSequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int bestLength = 0;
            int bestRow = -1;
            int bestCol = -1;

            int[,] lengths = CreateDPMatrix(firstSequence, secondSequence, bestLength, ref bestRow, ref bestCol);
            Stack<int> lis = GetLIS(firstSequence, secondSequence, lengths, bestRow, bestCol);

            Console.WriteLine(String.Join(' ', lis));
            Console.WriteLine(lis.Count);
        }

        private static int[,] CreateDPMatrix(int[] firstSequence, int[] secondSequence, int bestLength, ref int bestRow,
            ref int bestCol)
        {
            int[,] lengths = new int[firstSequence.Length + 1, secondSequence.Length + 1];

            for (int row = 1; row <= firstSequence.Length; row++)
            {
                for (int col = 1; col <= secondSequence.Length; col++)
                {
                    if (firstSequence[row - 1] == secondSequence[col - 1])
                    {
                        lengths[row, col] =
                            lengths[row - 1, col - 1] + 1;

                        if (lengths[row, col] > bestLength)
                        {
                            bestLength = lengths[row, col];
                            bestRow = row;
                            bestCol = col;
                        }
                    }
                    else
                    {
                        var up = lengths[row - 1, col];
                        var left = lengths[row, col - 1];
                        lengths[row, col] = Math.Max(up, left);
                    }
                }
            }

            return lengths;
        }

        private static Stack<int> GetLIS(int[] first, int[] second, int[,] dp, int row, int col)
        {
            Stack<int> lis = new Stack<int>();

            while (row > 0 && col > 0)
            {
                if (first[row - 1] == second[col - 1])
                {
                    lis.Push(first[row - 1]);
                    row--;
                    col--;
                }
                else if (dp[row - 1, col] > dp[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            return lis;
        }
    }
}

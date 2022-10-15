namespace _03._Code
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            var firstSequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var secondSequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var lcs = new int[firstSequence.Length + 1][];

            for (var row = 0; row < lcs.Length; row++)
            {
                lcs[row] = new int[secondSequence.Length + 1];
            }

            for (var row = 1; row < lcs.Length; row++)
            {
                for (var col = 1; col < lcs[row].Length; col++)
                {
                    if (firstSequence[row - 1] == secondSequence[col - 1])
                    {
                        lcs[row][col] = lcs[row - 1][col - 1] + 1;
                    }
                    else
                    {
                        lcs[row][col] = Math.Max(lcs[row - 1][col], lcs[row][col - 1]);
                    }
                }
            }

            var LCS = ReconstructingLCSSequence(lcs, firstSequence, secondSequence);
            Console.WriteLine(string.Join(" ", LCS));
            Console.WriteLine(LCS.Count);
        }

        private static Stack<int> ReconstructingLCSSequence(int[][] lcs, int[] firstString, int[] secondString)
        {
            var lcsSequence = new Stack<int>();
            var row = firstString.Length;
            var col = secondString.Length;

            while (row > 0 && col > 0)
            {
                if (firstString[row - 1] == secondString[col - 1])
                {
                    lcsSequence.Push(firstString[row - 1]);
                    row--;
                    col--;
                }
                else if (lcs[row - 1][col] > lcs[row][col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            return lcsSequence;
        }
    }
}

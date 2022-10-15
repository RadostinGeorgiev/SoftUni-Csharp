namespace _02._Mirror_String
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            string originalString = Console.ReadLine();
            string reversedString = new string(originalString.Reverse().ToArray());

            var lcs = new int[originalString.Length + 1][];

            for (var row = 0; row < lcs.Length; row++)
            {
                lcs[row] = new int[reversedString.Length + 1];
            }

            for (int row = 1; row < lcs.Length; row++)
            {
                for (int col = 1; col < lcs[row].Length; col++)
                {
                    if (originalString[row - 1] == reversedString[col - 1])
                    {
                        lcs[row][col] = lcs[row - 1][col - 1] + 1;
                    }
                    else
                    {
                        lcs[row][col] = Math.Max(lcs[row - 1][col], lcs[row][col - 1]);
                    }
                }
            }

            var LCS = ReconstructingLCSSequence(lcs, originalString, reversedString);

            //Console.WriteLine(lcs[originalString.Length, reversedString.Length]);
            Console.WriteLine(string.Join("", LCS));
        }

        private static Stack<char> ReconstructingLCSSequence(int[][] lcs, string firstString, string secondString)
        {
            var lcsSequence = new Stack<char>();
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

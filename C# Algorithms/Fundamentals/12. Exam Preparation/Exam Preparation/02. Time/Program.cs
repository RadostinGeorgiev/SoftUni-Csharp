namespace _02._Time
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static int[,] lcs;
        static void Main(string[] args)
        {
            int[] firstTimeLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondTimeLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

            lcs = new int[firstTimeLine.Length + 1, secondTimeLine.Length + 1];

            for (int row = 1; row < lcs.GetLength(0); row++)
            {
                for (int col = 1; col < lcs.GetLength(1); col++)
                {
                    if (firstTimeLine[row - 1] == secondTimeLine[col - 1])
                    {
                        lcs[row, col] = lcs[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        lcs[row, col] = Math.Max(lcs[row - 1, col], lcs[row, col - 1]);
                    }
                }
            }

            Console.WriteLine(ReconstructingLCSSequence(firstTimeLine, secondTimeLine));
            Console.WriteLine(lcs[firstTimeLine.Length, secondTimeLine.Length]);
        }

        private static string ReconstructingLCSSequence(int[] firstTimeLine, int[] secondTimeLine)
        {
            var lcsNumbers = new Stack<int>();
            var row = firstTimeLine.Length;
            var col = secondTimeLine.Length;

            while (row > 0 && col > 0)
            {
                if (firstTimeLine[row - 1] == secondTimeLine[col - 1])
                {
                    lcsNumbers.Push(firstTimeLine[row - 1]);
                    row--;
                    col--;
                }
                else if (lcs[row - 1, col] > lcs[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            return string.Join(' ', lcsNumbers);
        }
    }
}
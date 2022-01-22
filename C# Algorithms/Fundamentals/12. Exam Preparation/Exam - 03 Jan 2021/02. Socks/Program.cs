namespace _02._Socks
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] leftSocks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] rightSocks = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var lcs = new int[leftSocks.Length + 1, rightSocks.Length + 1];

            for (int row = 1; row < lcs.GetLength(0); row++)
            {
                for (int col = 1; col < lcs.GetLength(1); col++)
                {
                    if (leftSocks[row - 1] == rightSocks[col - 1])
                    {
                        lcs[row, col] = lcs[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        lcs[row, col] = Math.Max(lcs[row - 1, col], lcs[row, col - 1]);
                    }
                }
            }

            Console.WriteLine(lcs[leftSocks.Length, rightSocks.Length]);
        }
    }
}
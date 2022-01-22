namespace _06._Connecting_Cables
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] cableNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] wallNumbers = new int[cableNumbers.Length + 1];

            for (int i = 1; i < wallNumbers.Length; i++)
            {
                wallNumbers[i] = i;
            }
            
            var lcs = new int[cableNumbers.Length + 1, wallNumbers.Length + 1];

            for (int row = 1; row < lcs.GetLength(0); row++)
            {
                for (int col = 1; col < lcs.GetLength(1); col++)
                {
                    if (cableNumbers[row - 1] == wallNumbers[col - 1])
                    {
                        lcs[row, col] = lcs[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        lcs[row, col] = Math.Max(lcs[row - 1, col], lcs[row, col - 1]);
                    }
                }
            }

            Console.WriteLine($"Maximum pairs connected: {lcs[cableNumbers.Length, wallNumbers.Length]}");
        }
    }
}
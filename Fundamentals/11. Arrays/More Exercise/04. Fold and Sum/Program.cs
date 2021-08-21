using System;
using System.Linq;

namespace _04._Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] row = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int length = row.Length;
            int piece = length / 4;
            int[] topRow = new int[2 * piece];
            int[] bottomRow = new int[2 * piece];

            for (int i = 0; i < piece; i++)
            {
                topRow[i] = row[piece - 1 - i];
                topRow[piece + i] = row[length - 1 - i];
            }

            for (int i = 0; i < 2 * piece; i++)
            {
                bottomRow[i] = row[piece + i];
            }

            for (int i = 0; i < topRow.Length; i++)
            {
                int sum = topRow[i] + bottomRow[i];
                Console.Write(sum + " ");
            }
        }
    }
}

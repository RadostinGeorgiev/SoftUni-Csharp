namespace _02._Move_Down_Right
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int[,] dp = new int[rows, cols];
            dp[0, 0] = matrix[0, 0];

            for (int col = 1; col < cols; col++)
            {
                dp[0, col] = dp[0, col - 1] + matrix[0, col];
            }

            for (int row = 1; row < rows; row++)
            {
                dp[row, 0] = dp[row - 1, 0] + matrix[row, 0];
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    dp[row, col] = Math.Max(dp[row - 1, col], dp[row, col - 1]) + matrix[row, col];
                }
            }

            var path = new Stack<string>();
            var r = rows - 1;
            var c = cols - 1;

            while (r > 0 && c > 0)
            {
                path.Push($"[{r}, {c}]");

                if (dp[r - 1, c] > dp[r, c - 1])
                    r--;
                else
                    c--;
            }

            while (r > 0)
            {
                path.Push($"[{r}, {c}]");
                r--;
            }

            while (c > 0)
            {
                path.Push($"[{r}, {c}]");
                c--;
            }

            path.Push($"[{r}, {c}]");
            Console.WriteLine(string.Join(" ", path));
        }
    }
}
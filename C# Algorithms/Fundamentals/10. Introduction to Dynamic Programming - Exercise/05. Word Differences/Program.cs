namespace _05._Word_Differences
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();

            var dp = new int[firstString.Length + 1, secondString.Length + 1];

            for (int row = 0; row < dp.GetLength(0); row++)
            {
                dp[row, 0] = row;
            }

            for (int col = 0; col < dp.GetLength(1); col++)
            {
                dp[0, col] = col;
            }

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                for (int col = 1; col < dp.GetLength(1); col++)
                {
                    if (firstString[row - 1] == secondString[col - 1])
                        dp[row, col] = dp[row - 1, col - 1];
                    else
                        dp[row, col] = Math.Min(dp[row - 1, col], dp[row, col - 1]) + 1;
                }
            }

            Console.WriteLine($"Deletions and Insertions: {dp[firstString.Length, secondString.Length]}");
        }
    }
}
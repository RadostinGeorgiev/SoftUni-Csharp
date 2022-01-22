namespace _07._Minimum_Edit_Distance
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int replaceCost = int.Parse(Console.ReadLine());
            int insertCost = int.Parse(Console.ReadLine());
            int deleteCost = int.Parse(Console.ReadLine());
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();

            var dp = new int[firstString.Length + 1, secondString.Length + 1];

            for (int col = 1; col < dp.GetLength(1); col++)
            {
                dp[0, col] = dp[0, col - 1] + insertCost;
            }

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                dp[row, 0] = dp[row - 1, 0] + deleteCost;
            }

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                for (int col = 1; col < dp.GetLength(1); col++)
                {
                    if (firstString[row - 1] == secondString[col - 1])
                    {
                        dp[row, col] = dp[row - 1, col - 1];
                    }
                    else
                    {
                        var replace = dp[row - 1, col - 1] + replaceCost;
                        var delete = dp[row - 1, col] + deleteCost;
                        var insert = dp[row, col - 1] + insertCost;

                        dp[row, col] = Math.Min(replace, Math.Min(delete, insert));
                    }
                }
            }

            Console.WriteLine($"Minimum edit distance: {dp[firstString.Length, secondString.Length]}");
        }
    }
}
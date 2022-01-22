namespace _01._Binomial_Coefficients
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static Dictionary<string, long> cache;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            cache = new Dictionary<string, long>();
            Console.WriteLine(GetBinom(n, k));
        }

        private static long GetBinom(int row, int col)
        {
            if (cache.ContainsKey($"{row}, {col}"))
            {
                return cache[$"{row}, {col}"];
            }
            if (row == 0 || col == 0 || col == row)
            {
                return 1;
            }

            var result = GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);
            cache[$"{row}, {col}"] = result;

            return result;
        }
    }
}
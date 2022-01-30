namespace _01._Move_Down_Right
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static Dictionary<string, long> cache;

        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            cache = new Dictionary<string, long>();
            Console.WriteLine(GetPathNumber(m, n));
        }

        private static long GetPathNumber(int row, int col)
        {
            if (cache.ContainsKey($"{row}, {col}"))
            {
                return cache[$"{row}, {col}"];
            }

            if (row == 1 || col == 1)
            {
                return 1;
            }

            var result = GetPathNumber(row - 1, col) + GetPathNumber(row, col - 1);
            cache[$"{row}, {col}"] = result;

            return result;
        }
    }
}
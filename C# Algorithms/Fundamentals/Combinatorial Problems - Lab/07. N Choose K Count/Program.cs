namespace _07._N_Choose_K_Count
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine(GetNumber(n, k));
        }

        private static int GetNumber(int row, int col)
        {
            if (row == 0 || col == 0 || col == row)
            {
                return 1;
            }

            return GetNumber(row - 1, col - 1) + GetNumber(row - 1, col);
        }
    }
}
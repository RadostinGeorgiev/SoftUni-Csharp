using System;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            long[][] triangle = new long[size][];

            for (int row = 0; row < size; row++)
            {
                triangle[row] = new long[row + 1];
                triangle[row][0] = 1;
                triangle[row][row] = 1;

                for (int column = 1; column < row; column++)
                {
                    triangle[row][column] = triangle[row - 1][column - 1] + triangle[row - 1][column];
                }

                Console.WriteLine(string.Join(' ', triangle[row]));
            }
        }
    }
}

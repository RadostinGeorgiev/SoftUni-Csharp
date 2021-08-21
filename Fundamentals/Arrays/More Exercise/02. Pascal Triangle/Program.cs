using System;

namespace _02._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsNumber = int.Parse(Console.ReadLine());

            long[] prevRow = { 1 };
            Console.WriteLine(1);

            for (int row = 2; row <= rowsNumber; row++)
            {
                long[] currentRow = new long[row];
                currentRow[0] = 1;
                currentRow[currentRow.Length - 1] = 1;

                if (row > 2)
                {
                    for (int column = 1; column <= currentRow.Length - 2; column++)
                    {
                        currentRow[column] = prevRow[column - 1] + prevRow[column];
                    }
                }

                prevRow = currentRow;
                Console.WriteLine(string.Join(' ', currentRow));
            }
        }
    }
}

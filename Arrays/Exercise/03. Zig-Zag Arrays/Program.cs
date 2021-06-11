using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[] array1 = new int[rows];
            int[] array2 = new int[rows];

            for (int i = 0; i <= rows - 1; i++)
            {
                string currentRow = Console.ReadLine();
                int[] currentNumbers = currentRow.Split()
                    .Select(int.Parse)
                    .ToArray();

                if (i % 2 == 0)
                {
                    array1[i] = currentNumbers[0];
                    array2[i] = currentNumbers[1];
                }
                else
                {
                    array1[i] = currentNumbers[1];
                    array2[i] = currentNumbers[0];
                }
            }

            Console.WriteLine(String.Join(' ', array1));
            Console.WriteLine(String.Join(' ', array2));
        }
    }
}

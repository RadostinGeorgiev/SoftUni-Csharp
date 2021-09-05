using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                    .Split()
                    .Select(double.Parse)
                    .ToArray();
            }

            for (int row = 1; row < rows; row++)
            {
                if (jaggedArray[row - 1].Length == jaggedArray[row].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row - 1][col] *= 2;
                        jaggedArray[row][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row - 1].Length; col++)
                    {
                        jaggedArray[row - 1][col] /= 2;
                    }
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }
                }
            }

            string input = String.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input.Split();
                string command = commands[0];
                int row = int.Parse(commands[1]);
                int column = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                if (row >= 0 && row < jaggedArray.Length && column >= 0 && column < jaggedArray[row].Length)
                {
                    switch (command)
                    {
                        case "Add":
                            jaggedArray[row][column] += value;
                            break;
                        case "Subtract":
                            jaggedArray[row][column] -= value;
                            break;
                    }
                }
            }

            PrintJaggedArray(rows, jaggedArray);
        }

        private static void PrintJaggedArray(int rows, double[][] jaggedArray)
        {
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(' ', jaggedArray[row]));
            }
        }
    }
}

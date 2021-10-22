using System;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] coordinates = new int[3, 2];
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            FillMatrix(size, matrix, ref coordinates);

            int money = 0;

            while (money < 50)
            {
                string command = Console.ReadLine();

                if (MoveSeller(matrix, command, ref coordinates))
                {
                    money += ActionSeller(matrix, coordinates);
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(money < 50
                ? "Bad news, you are out of the bakery."
                : "Good news! You succeeded in collecting enough money!");
            Console.WriteLine($"Money: {money}");

            PrintMattrix(size, matrix);
        }

        private static void PrintMattrix(int size, char[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static int ActionSeller(char[,] matrix, int[,] coordinates)
        {
            int row = coordinates[0, 0];
            int col = coordinates[0, 1];
            int money = 0;

            if (char.IsDigit(matrix[row, col]))
            {
                money = int.Parse(matrix[row, col].ToString());
            }

            coordinates[0, 0] = row;
            coordinates[0, 1] = col;
            matrix[row, col] = 'S';
            return money;
        }

        private static bool CheckCoordinates(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }

        private static bool MoveSeller(char[,] matrix, string command, ref int[,] coordinates)
        {
            int row = coordinates[0, 0];
            int col = coordinates[0, 1];
            matrix[row, col] = '-';

            switch (command)
            {
                case "up": row--; break;
                case "down": row++; break;
                case "left": col--; break;
                case "right": col++; break;
            }

            if (CheckCoordinates(matrix, row, col))
            {
                if (matrix[row, col] == 'O')
                {
                    int pillarOneRow = coordinates[1, 0];
                    int pillarOneCol = coordinates[1, 1];
                    int pillarTwoRow = coordinates[2, 0];
                    int pillarTwoCol = coordinates[2, 1];
                    matrix[row, col] = '-';

                    if (row == pillarOneRow && col == pillarOneCol)
                    {
                        row = pillarTwoRow;
                        col = pillarTwoCol;
                    }
                    else
                    {
                        row = pillarOneRow;
                        col = pillarOneCol;
                    }

                    matrix[row, col] = 'S';
                }

                coordinates[0, 0] = row;
                coordinates[0, 1] = col;

                return true;
            }

            return false;
        }

        private static void FillMatrix(int size, char[,] matrix, ref int[,] coordinates)
        {
            bool isFoundPillar = false;
            for (int row = 0; row < size; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (currentRow[col] == 'S')
                    {
                        coordinates[0, 0] = row;      //seller row index
                        coordinates[0, 1] = col;     //seller col index
                    }
                    if (currentRow[col] == 'O')
                    {
                        if (!isFoundPillar)
                        {
                            coordinates[1, 0] = row; //pillar1 row index
                            coordinates[1, 1] = col; //pillar1 col index
                            isFoundPillar = true;
                        }
                        else
                        {
                            coordinates[2, 0] = row; //pillar2 row index
                            coordinates[2, 1] = col; //pillar2 col index
                        }
                    }
                }
            }
        }
    }
}
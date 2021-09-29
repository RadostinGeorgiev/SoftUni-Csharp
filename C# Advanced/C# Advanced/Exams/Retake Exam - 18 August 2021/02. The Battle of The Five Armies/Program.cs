using System;

namespace _02._The_Battle_of_The_Five_Armies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            char[][] matrix = new char[size][];
            int armyPosRow = 0;
            int armyPosCol = 0;

            CreateMatrix(size, matrix, ref armyPosRow, ref armyPosCol);

            while (armor > 0)
            {
                string[] commandArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string direction = commandArgs[0];
                int enemySpawnRow = int.Parse(commandArgs[1]);
                int enemySpawnCol = int.Parse(commandArgs[2]);

                SpawnEnemy(matrix, enemySpawnRow, enemySpawnCol);
                int moveResult = MoveArmy(direction, matrix, ref armyPosRow, ref armyPosCol, ref armor);

                if (moveResult == -1)
                {
                    Console.WriteLine($"The army was defeated at {armyPosRow};{armyPosCol}.");
                    break;
                }
                if (moveResult == 1)
                {
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    break;
                }
            }

            PrintMatrix(matrix);
        }

        private static void CreateMatrix(int size, char[][] matrix, ref int armyPosRow, ref int armyPosCol)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'A')
                    {
                        armyPosRow = row;
                        armyPosCol = col;
                    }
                }
            }
        }

        private static void SpawnEnemy(char[][] matrix, int row, int col)
        {
            matrix[row][col] = 'O';
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var c in matrix)
            {
                Console.WriteLine(string.Join("", c));
            }
        }

        private static int MoveArmy(string direction, char[][] matrix, ref int row, ref int col, ref int armor)
        {
            matrix[row][col] = '-';
            armor--;

            switch (direction)
            {
                case "up":
                    row--;
                    if (row < 0)
                    {
                        row = 0;
                    }
                    break;
                case "down":
                    row++;
                    if (row == matrix.Length)
                    {
                        row = matrix.Length - 1;
                    }
                    break;
                case "left":
                    col--;
                    if (col < 0)
                    {
                        col = 0;
                    }
                    break;
                case "right":
                    col++;
                    if (col == matrix[row].Length)
                    {
                        col = matrix[row].Length - 1;
                    }
                    break;
            }

            if (matrix[row][col] == 'M')
            {
                matrix[row][col] = '-';
                return 1;
            }

            if (matrix[row][col] == 'O')
            {
                armor -= 2;
            }

            if (armor <= 0)
            {
                matrix[row][col] = 'X';
                return -1;
            }

            matrix[row][col] = 'A';
            return 0;
        }

    }
}
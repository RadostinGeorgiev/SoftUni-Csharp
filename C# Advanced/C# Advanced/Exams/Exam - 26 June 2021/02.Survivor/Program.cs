using System;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string[][] array = new string[rows][];

            for (int i = 0; i < rows; i++)
            {
                array[i] = Console.ReadLine().Split();
            }

            int survivorTokens = 0;
            int opponentTokens = 0;

            string input;
            while ((input = Console.ReadLine()) != "Gong")
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);

                switch (command[0])
                {
                    case "Find":
                        if (GetToken(array, row, col))
                        {
                            survivorTokens++;
                        }
                        break;

                    case "Opponent":
                        if (GetToken(array, row, col))
                        {
                            opponentTokens++;

                            string direction = command[3];
                            for (int i = 0; i < 3; i++)
                            {
                                switch (direction)
                                {
                                    case "up": row--; break;
                                    case "down": row++; break;
                                    case "left": col--; break;
                                    case "right": col++; break;
                                }

                                if (!CheckPosition(array, row, col))
                                {
                                    break;
                                }

                                if (GetToken(array, row, col))
                                {
                                    opponentTokens++;
                                }
                            }
                        }

                        break;
                }
            }

            PrintArray(array);
            Console.WriteLine($"Collected tokens: {survivorTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        private static void PrintArray(string[][] array)
        {
            foreach (var row in array)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }

        private static bool GetToken(string[][] array, int row, int col)
        {
            if (CheckPosition(array, row, col))
            {
                if (array[row][col] == "T")
                {
                    array[row][col] = "-";
                    return true;
                }
            }

            return false;
        }

        private static bool CheckPosition(string[][] array, int row, int col)
        {
            return row >= 0 && row < array.Length && col >= 0 && col < array[row].Length;
        }
    }
}
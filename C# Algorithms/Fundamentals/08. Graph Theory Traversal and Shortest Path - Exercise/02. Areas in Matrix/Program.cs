namespace _02._Areas_in_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static char[,] graph;
        private static bool[,] visited;
        private static SortedDictionary<char, int> areas;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            graph = new char[rows, cols];
            visited = new bool[rows, cols];
            areas = new SortedDictionary<char, int>();

            ReadGraph(rows, cols);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (visited[row, col]) continue;

                    var value = graph[row, col];

                    DFS(row, col, value);

                    if (!areas.ContainsKey(value))
                    {
                        areas.Add(value, 0);
                    }

                    areas[value]++;
                }
            }

            Console.WriteLine($"Areas: {areas.Sum(a => a.Value)}");
            foreach (var area in areas)
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void DFS(int row, int col, char value)
        {
            if (row < 0 || row >= graph.GetLength(0) ||
                col < 0 || col >= graph.GetLength(1))
            {
                return;
            }

            if (visited[row, col])
            {
                return;
            }

            if (graph[row, col] != value)
            {
                return;
            }

            visited[row, col] = true;

            DFS(row - 1, col, value);
            DFS(row + 1, col, value);
            DFS(row, col - 1, value);
            DFS(row, col + 1, value);
        }

        private static void ReadGraph(int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    graph[row, col] = currentRow[col];
                }
            }
        }
    }
}
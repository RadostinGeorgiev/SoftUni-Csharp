namespace _01._Connected_Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());

            ReadGraph(nodes);
            FindGraphConnectedComponents(nodes);
        }

        private static void FindGraphConnectedComponents(int nodes)
        {
            visited = new bool[nodes];

            for (var node = 0; node < graph.Length; node++)
            {
                if (visited[node]) continue;

                Console.Write("Connected component:");
                DFS(node);
                Console.WriteLine();
            }
        }

        private static void ReadGraph(int nodes)
        {
            graph = new List<int>[nodes];

            for (int node = 0; node < nodes; node++)
            {
                var child = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                graph[node] = child.Count == 0 ? new List<int>() : child;
            }
        }

        private static void DFS(int node)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            Console.Write(" " + node);
        }
    }
}
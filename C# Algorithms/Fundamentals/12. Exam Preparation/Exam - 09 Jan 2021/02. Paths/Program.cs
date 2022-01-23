namespace _02._Paths
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static List<int>[] graph;
        public static bool[] visited;
        public static List<int> path;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());

            graph = new List<int>[nodes];

            ReadGraph(nodes);

            for (var startNode = 0; startNode < graph.Length - 1; startNode++)
            {
                visited = new bool[nodes];
                path = new List<int>() {startNode};

                DFS(startNode, graph.Length -1);
            }
        }

        private static void DFS(int node, int destination)
        {
            if (node == destination)
            {
                Console.WriteLine(string.Join(' ', path));
                return;
            }

            if (visited[node]) return;

            visited[node] = true;

            foreach (var child in graph[node])
            {
                path.Add(child);

                DFS(child, destination);

                path.RemoveAt(path.Count -1);
            }

            visited[node] = false;
        }

        private static void ReadGraph(int nodes)
        {
            for (int node = 0; node < nodes; node++)
            {
                graph[node] = new List<int>();

                var children = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                if (children.Count > 0)
                {
                    graph[node] = children;
                }
            }
        }
    }
}
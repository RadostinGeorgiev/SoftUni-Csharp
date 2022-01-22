namespace _06._Road_Reconstruct
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
    }

    class Program
    {
        public static List<int>[] graph;
        public static bool[] visited;
        public static List<Edge> edges;

        static void Main(string[] args)
        {
            int buildingsNumber = int.Parse(Console.ReadLine());
            int streetsNumber = int.Parse(Console.ReadLine());

            graph = new List<int>[buildingsNumber];

            for (int i = 0; i < buildingsNumber; i++)
            {
                graph[i] = new List<int>();
            }

            edges = new List<Edge>();
            for (int i = 0; i < streetsNumber; i++)
            {
                int[] edgeArgs = Console.ReadLine()
                    .Split(" - ")
                    .Select(int.Parse)
                    .ToArray();
                int node = edgeArgs[0];
                int child = edgeArgs[1];

                graph[node].Add(child);
                graph[child].Add(node);
                edges.Add(new Edge() { First = node, Second = child });
            }

            Console.WriteLine("Important streets:");
            foreach (var edge in edges)
            {
                graph[edge.First].Remove(edge.Second);
                graph[edge.Second].Remove(edge.First);

                visited = new bool[buildingsNumber];
                DFS(0);

                if (visited.Contains(false))
                {
                    Console.WriteLine(edge.First < edge.Second
                        ? $"{edge.First} {edge.Second}"
                        : $"{edge.Second} {edge.First}");
                }

                graph[edge.First].Add(edge.Second);
                graph[edge.Second].Add(edge.First);
            }
        }

        private static void DFS(int node)
        {
            if (visited[node]) return;

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child);
            }
        }
    }
}
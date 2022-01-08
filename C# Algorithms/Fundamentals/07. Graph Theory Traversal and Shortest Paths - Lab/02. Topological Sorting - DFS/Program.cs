namespace _02._Topological_Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;
        private static Stack<string> sorted;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());

            ReadGraph(nodes);

            visited = new HashSet<string>();
            cycles = new HashSet<string>();
            sorted = new Stack<string>();

            foreach (var node in graph.Keys)
            {
                try
                {
                    DFS(node);

                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
        }

        private static void DFS(string node)
        {
            if (cycles.Contains(node))
            {
                throw new InvalidOperationException("Invalid topological sorting");
            }

            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);
            cycles.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            cycles.Remove(node);
            sorted.Push(node);
        }

        private static void ReadGraph(int nodes)
        {
            graph = new Dictionary<string, List<string>>();

            for (int i = 0; i < nodes; i++)
            {
                string[] nodesInfo = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .ToArray();

                string node = nodesInfo[0];

                if (nodesInfo.Length == 1)
                {
                    graph[node] = new List<string>();
                }
                else
                {
                    List<string> child = nodesInfo[1]
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    graph[node] = child;
                }
            }
        }
    }
}
namespace _03._The_Story_Telling
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
            graph = new Dictionary<string, List<string>>();

            ReadGraph();
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

            Console.WriteLine($"{string.Join(' ', sorted)}");
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

        private static void ReadGraph()
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var inputArgs = input
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();
                var node = inputArgs[0];

                if (inputArgs.Length == 1)
                {
                    graph[node] = new List<string>();
                }
                else
                {
                    graph[node] = inputArgs[1].Split().ToList();
                }
            }
        }
    }
}
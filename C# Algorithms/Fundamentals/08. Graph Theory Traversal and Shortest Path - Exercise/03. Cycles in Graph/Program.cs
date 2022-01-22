namespace _03._Cycles_in_Graph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static Dictionary<char, List<char>> graph;
        private static HashSet<char> visited;
        private static HashSet<char> cycles;

        static void Main(string[] args)
        {
            graph = new Dictionary<char, List<char>>();
            visited = new HashSet<char>();
            cycles = new HashSet<char>();

            ReadGraph();

            try
            {
                foreach (var node in graph.Keys)
                {
                    DFS(node);
                }

                Console.WriteLine("Acyclic: Yes");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Acyclic: No");
            }
        }

        private static void DFS(char node)
        {
            if (cycles.Contains(node))
            {
                throw new InvalidOperationException();
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
        }

        private static void ReadGraph()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                char[] nodeArgs = input
                    .Split('-')
                    .Select(char.Parse)
                    .ToArray();
                char node = nodeArgs[0];
                char child = nodeArgs[1];

                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<char>());
                }

                if (!graph.ContainsKey(child))
                {
                    graph.Add(child, new List<char>());
                }

                graph[node].Add(child);
            }
        }
    }
}
namespace _02._Universes
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        public static Dictionary<string, List<string>> graph;
        public static HashSet<string> visited;

        static void Main(string[] args)
        {
            int planets = int.Parse(Console.ReadLine());

            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();
            
            ReadGraph(planets);

            var connections = 0;
            foreach (var planet in graph.Keys)
            {
                if (visited.Contains(planet))
                {
                    continue;
                }

                DFS(planet);
                connections++;
            }

            Console.WriteLine(connections);
        }

        private static void DFS(string node)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }
        }

        private static void ReadGraph(int planets)
        {
            for (int node = 0; node < planets; node++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(" - ");
                var planet = inputArgs[0];
                var connection = inputArgs[1];

                if (!graph.ContainsKey(planet))
                {
                    graph[planet] = new List<string>();
                }

                if (!graph.ContainsKey(connection))
                {
                    graph[connection] = new List<string>();
                }

                graph[planet].Add(connection);
                graph[connection].Add(planet);
            }
        }
    }
}
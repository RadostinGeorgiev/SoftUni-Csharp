namespace _05._Break_Cycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Edge
    {
        public string Start { get; set; }
        public string End { get; set; }

        public override string ToString()
        {
            return $"{Start} - {End}";
        }
    }

    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static List<Edge> edges;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            graph = new Dictionary<string, List<string>>();
            edges = new List<Edge>();


            for (int i = 0; i < nodes; i++)
            {
                string[] graphArgs = Console.ReadLine().Split(" -> ");
                var node = graphArgs[0];
                List<string> children = graphArgs[1].Split().ToList();

                graph.Add(node, children);

                foreach (var child in children)
                {
                    edges.Add(new Edge { Start = node, End = child });
                }
            }

            edges = edges.OrderBy(e => e.Start)
                .ThenBy(e => e.End)
                .ToList();

            var removedEdges = new List<Edge>();

            foreach (var edge in edges)
            {
                var removed = graph[edge.Start].Remove(edge.End) &&
                              graph[edge.End].Remove(edge.Start);

                if (!removed)
                {
                    continue;
                }

                if (BFS(edge.Start, edge.End))
                {
                    removedEdges.Add(edge);
                }
                else
                {
                    graph[edge.Start].Remove(edge.End);
                    graph[edge.End].Remove(edge.Start);
                };
            }

            Console.WriteLine($"Edges to remove: {removedEdges.Count}");
            foreach (var edge in removedEdges)
            {
                Console.WriteLine(edge);
            }
        }

        private static bool BFS(string start, string destination)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(start);

            HashSet<string> visited = new HashSet<string>() { start };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return true;
                }

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child)) continue;

                    queue.Enqueue(child);
                    visited.Add(child);
                }

            }

            return false;
        }
    }
}
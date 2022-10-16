namespace _02._Longest_Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Edge
    {
        public int From { get; set; }
        public int To { get; set; }
        public int Weight { get; set; }

        public Edge()
        {
            From = To = Weight = 0;
        }

        public override string ToString()
        {
            return string.Format($"({this.From}-{this.To}) -> {this.Weight}");
        }
    }

    class Graph
    {
        public int VerticesCount { get; set; }
        public int EdgesCount { get; set; }
        public Dictionary<int, List<Edge>> Nodes;

        public Graph(int verticesCount, int edgesCount)
        {
            this.VerticesCount = verticesCount;
            this.EdgesCount = edgesCount;

            this.Nodes = new Dictionary<int, List<Edge>>(verticesCount);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());
            Graph graph = new Graph(nodes, edges);

            graph = ReadGraphFromConsole(graph);

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            var sortedNodes = TopologicalSorting(graph);

            double[] distance = new double[nodes + 1];
            int[] parents = new int[graph.VerticesCount + 1];

            Array.Fill(distance, double.NegativeInfinity);               //For Min distance use PositiveInfinity
            Array.Fill(parents, -1);

            distance[source] = 0;

            while (sortedNodes.Count != 0)
            {
                var node = sortedNodes.Pop();

                foreach (var edge in graph.Nodes[node])
                {
                    var newDistance = distance[edge.From] + edge.Weight;

                    if (newDistance > distance[edge.To])                            //For Min distance use <
                    {
                        distance[edge.To] = newDistance;
                        parents[edge.To] = edge.From;
                    }
                }
            }

            Console.WriteLine(distance[destination]);

            //var path = GetPath(parents, destination);
            //Console.WriteLine(string.Join(" ", path));
        }

        private static Graph ReadGraphFromConsole(Graph graph)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                                      .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();

                int from = edgeData[0];
                int to = edgeData[1];

                if (!graph.Nodes.ContainsKey(from))
                {
                    graph.Nodes.Add(from, new List<Edge>());
                }

                if (!graph.Nodes.ContainsKey(to))
                {
                    graph.Nodes.Add(to, new List<Edge>());
                }

                graph.Nodes[from].Add(new Edge
                {
                    From = from,
                    To = to,
                    Weight = edgeData[2],
                });
            }

            return graph;
        }

        private static Stack<int> TopologicalSorting(Graph graph)                   //For Directed Acyclic Graph (DAG) DFS is easiest way
        {
            Stack<int> result = new Stack<int>();                                   // DFS uses stack as a base
            HashSet<int> visited = new HashSet<int>();

            foreach (var node in graph.Nodes.Keys)                              //DFS for all vertices in graph
            {
                DFS(node, graph, visited, result);
            }

            return result;
        }

        private static void DFS(int node, Graph graph, HashSet<int> visited, Stack<int> result)
        {
            if (visited.Contains(node))                                         //Execute the method only if current vertex is not visited yet
            {
                return;
            }

            visited.Add(node);                                                  //Mark node as visited

            foreach (var edge in graph.Nodes[node])                                 //Check all edges of current vertex
            {
                DFS(edge.To, graph, visited, result);
            }

            result.Push(node);
        }

        private static Stack<int> GetPath(int[] prev, int node)
        {
            Stack<int> path = new Stack<int>();

            while (node != -1)
            {
                path.Push(node);
                node = prev[node];
            }

            return path;
        }
    }
}
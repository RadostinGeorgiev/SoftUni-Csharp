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
    }

    class Graph
    {
        public int VerticesCount;
        public int EdgesCount;
        public Dictionary<int, List<Edge>> nodes;

        public Graph(int verticesCount, int edgesCount)
        {
            this.VerticesCount = verticesCount;
            this.EdgesCount = edgesCount;

            nodes = new Dictionary<int, List<Edge>>(verticesCount);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());
            Graph graph = new Graph(nodes, edges);

            graph = FillInEdgesGraphFromConsole(graph);

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            var sortedNodes = TopologicalSorting(graph);

            double[] distance = new double[nodes + 1];
            int[] parents = new int[graph.VerticesCount + 1];

            Array.Fill(distance, double.NegativeInfinity);      //For Min distance use PositiveInfinity
            Array.Fill(parents, -1);

            distance[source] = 0;

            while (sortedNodes.Count != 0)
            {
                var node = sortedNodes.Pop();

                foreach (var edge in graph.nodes[node])
                {
                    var newDistance = distance[edge.From] + edge.Weight;
                    if (newDistance > distance[edge.To])        //For Min distance use <
                    {
                        distance[edge.To] = newDistance;
                        parents[edge.To] = edge.From;
                    }
                }
            }

            Console.WriteLine(distance[destination]);
            //GetPath(parents, destination);
        }

        private static Graph FillInEdgesGraphFromConsole(Graph graph)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

                int from = edgeData[0];
                int to = edgeData[1];

                if (!graph.nodes.ContainsKey(from))
                {
                    graph.nodes.Add(from, new List<Edge>());
                }

                if (!graph.nodes.ContainsKey(to))
                {
                    graph.nodes.Add(to, new List<Edge>());
                }

                graph.nodes[from].Add(new Edge
                {
                    From = from,
                    To = to,
                    Weight = edgeData[2],
                });
            }

            return graph;
        }
        private static Stack<int> TopologicalSorting(Graph graph) //For Directed Acyclic Graph (DAG) DFS is easiest way
        {
            Stack<int> result = new Stack<int>();               // DFS uses stack as a base
            HashSet<int> visited = new HashSet<int>();

            foreach (var node in graph.nodes.Keys)              //DFS for all vertices in graph
            {
                DFS(node, graph, visited, result);
            }
            return result;
        }
        private static void DFS(int node, Graph graph, HashSet<int> visited, Stack<int> result)
        {
            if (visited.Contains(node))                         //Execute the method only if current vertex is not visited yet
            {
                return;
            }

            visited.Add(node);                                  //Mark node as visited

            foreach (var edge in graph.nodes[node])             //Check all edges of current vertex
            {
                DFS(edge.To, graph, visited, result);
            }

            result.Push(node);
        }
        private static void GetPath(int[] prev, int node)
        {
            Stack<int> path = new Stack<int>();

            while (node != -1)
            {
                path.Push(node);
                node = prev[node];
            }

            Console.WriteLine(String.Join(' ', path));
        }
    }
}

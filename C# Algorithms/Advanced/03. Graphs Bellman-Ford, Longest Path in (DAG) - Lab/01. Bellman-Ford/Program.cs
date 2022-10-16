namespace _03._Graphs_Bellman_Ford__Longest_Path_in__DAG_
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
        public List<Edge> Edges;

        public Graph(int verticesCount, int edgesCount)
        {
            this.VerticesCount = verticesCount;
            this.EdgesCount = edgesCount;

            this.Edges = new List<Edge>(edgesCount);
        }
    }

    internal class Program
    {
        static double[] distance;
        static int[] parents;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            Graph graph = new Graph(nodes, edges);
            graph = ReadGraphFromConsole(graph);

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            if (BellmanFord(graph, source))
            {
                Stack<int> path = GetPath(parents, destination);

                Console.WriteLine(string.Join(" ", path));
                Console.WriteLine(distance[destination]);
            }
            else
            {
                Console.WriteLine("Negative Cycle Detected");
            } ;
        }

        private static Graph ReadGraphFromConsole(Graph graph)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                                      .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();

                graph.Edges.Add(new Edge
                {
                    From = edgeData[0],
                    To = edgeData[1],
                    Weight = edgeData[2],
                });
            }

            return graph;
        }

        private static bool BellmanFord(Graph graph, int source)
        {
            distance = new double[graph.VerticesCount + 1];
            parents = new int[graph.VerticesCount + 1];

            // Step 1: Initialize distances array from source vertex to all other vertices as INFINITE
            //         Initialize parents array with invalid indexes 
            Array.Fill(distance, double.PositiveInfinity);
            Array.Fill(parents, -1);

            distance[source] = 0; // Initialize start vertex

            // Step 2: Initialize distances array from source vertex to all other vertices as INFINITE
            for (int i = 1; i < graph.VerticesCount; ++i)
            {
                var updated = false;

                //Relaxing each edge by traversing from each vertex and so complexity is O(V.E)
                foreach (Edge edge in graph.Edges)
                {
                    if (double.IsPositiveInfinity(distance[edge.From]))
                    {
                        continue;
                    }

                    var newDistance = distance[edge.From] + edge.Weight;

                    if (newDistance < distance[edge.To])
                    {
                        distance[edge.To] = newDistance;
                        parents[edge.To] = edge.From;
                        updated = true;
                    }
                }

                if (!updated)
                {
                    break;
                }
            }

            //Step 3: detect negative cycle:
            //      if value changes then we have a negative cycle in the graph and we cannot find the shortest distances
            foreach (Edge edge in graph.Edges)
            {
                if (double.IsPositiveInfinity(distance[edge.From]))
                {
                    continue;
                }

                if (distance[edge.To] > distance[edge.From] + edge.Weight)
                {
                    return false;
                }
            }

            return true;
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
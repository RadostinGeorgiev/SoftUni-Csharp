namespace _03._Undefined
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
        public List<Edge> edges;

        public Graph(int verticesCount, int edgesCount)
        {
            this.VerticesCount = verticesCount;
            this.EdgesCount = edgesCount;

            edges = new List<Edge>(edgesCount);
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

            graph = FillInEdgesGraphFromConsole(graph);

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            if (BellmanFord(graph, source))
            {
                GetPath(parents, destination);
                Console.WriteLine(distance[destination]);
            }
            else
            {
                Console.WriteLine("Undefined");
            };
        }

        private static Graph FillInEdgesGraphFromConsole(Graph graph)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();
                graph.edges.Add(new Edge
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
            //         Initialize parrents array with invalid indexes 
            Array.Fill(distance, double.PositiveInfinity);
            Array.Fill(parents, -1);

            distance[source] = 0;                                           // Initialize start vertex

            // Step 2: Initialize distances array from source vertex to all other vertices as INFINITE
            for (int i = 1; i < graph.VerticesCount; ++i)
            {
                var updated = false;

                //Relaxing each edge by traversing from each vertex and so complexity is O(V.E)
                foreach (Edge edge in graph.edges)
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
            foreach (Edge edge in graph.edges)
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

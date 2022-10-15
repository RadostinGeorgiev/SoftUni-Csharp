namespace _02._Picker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Weight { get; set; }
        public override string ToString()
        {
            return string.Format($"({this.First}-{this.Second}) -> {this.Weight}");
        }
    }
    class Graph
    {
        public int VerticesCount;
        public int EdgesCount;
        public List<Edge> Edges;

        public Graph(int verticesCount, int edgesCount)
        {
            this.VerticesCount = verticesCount;
            this.EdgesCount = edgesCount;

            Edges = new List<Edge>();
        }
    }
    internal class Program
    {
        static int[] parents;
        static void Main(string[] args)
        {
            int spheres = int.Parse(Console.ReadLine());
            int bars = int.Parse(Console.ReadLine());
            Graph graph = new Graph(spheres, bars);

            //Kruskal’s Algorithm O(E.logV) -> for smaller graphs
            graph = ReadEdgesGraphFromConsole(graph);
            var MST = MSTKruskal(graph);
            MST.ForEach(edge => Console.WriteLine($"{edge.First} {edge.Second}"));
            Console.WriteLine(MST.Sum(x=> x.Weight));
        }
        private static Graph ReadEdgesGraphFromConsole(Graph graph)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                                        .Split( )
                                        .Select(int.Parse)
                                        .ToArray();
                graph.Edges.Add(new Edge
                {
                    First = edgeData[0],
                    Second = edgeData[1],
                    Weight = edgeData[2],
                });
            }

            return graph;
        }

        private static List<Edge> MSTKruskal(Graph graph)                         //Minimum Spanning Tree - Kruskal’s algorithm 
        {
            List<Edge> forest = new List<Edge>();

            List<int> nodes = graph.Edges                                         //get Graph's nodes from edge's structure
                            .Select(e => e.First)
                            .Union(graph.Edges.Select(e => e.Second))
                            .Distinct()
                            .ToList();

            parents = new int[nodes.Max() + 1];
            nodes.ForEach(node => parents[node] = node);                     //initialize forest as self parent graphs

            List<Edge> sortedEdges = graph.Edges.OrderBy(e => e.Weight).ToList();
            sortedEdges.ForEach(edge =>
            {
                var firstRoot = FindRoot(edge.First);
                var secondRoot = FindRoot(edge.Second);

                if (firstRoot != secondRoot)
                {
                    parents[secondRoot] = firstRoot;
                    forest.Add(edge);
                }
            });

            return forest;
        }
        static int FindRoot(int node)
        {
            while (parents[node] != node)
            {
                node = parents[node];
            }

            return node;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Black_Friday
{
    class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Time { get; set; }                               //Weight
        public override string ToString()
        {
            return string.Format($"{this.First} -> {this.Second} ({this.Time})");
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

            this.Edges = new List<Edge>();
        }
    }
    internal class Program
    {
        static int[] parents;
        static void Main(string[] args)
        {
            int shops = int.Parse(Console.ReadLine());
            int streets = int.Parse(Console.ReadLine());
            Graph graph = new Graph(shops, streets);

            graph = ReadEdgesGraphFromConsole(graph, streets);

            var MST = MSTKruskal(graph);

            int totalTime = MST.Sum(x => x.Time);
            Console.WriteLine($"{totalTime}");
            //MST.ForEach(edge => Console.WriteLine(edge));
        }

        private static Graph ReadEdgesGraphFromConsole(Graph graph, int edges)
        {
            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToArray();
                graph.Edges.Add(new Edge
                {
                    First = edgeData[0],
                    Second = edgeData[1],
                    Time = edgeData[2],
                });
            }

            return graph;
        }

        private static List<Edge> MSTKruskal(Graph graph)                               //Minimum Spanning Tree - Kruskal’s algorithm 
        {
            List<Edge> forest = new List<Edge>();

            List<int> nodes = graph.Edges                                         //get Graph's nodes from edge's structure
                            .Select(e => e.First)
                            .Union(graph.Edges.Select(e => e.Second))
                            .Distinct()
                            .ToList();

            parents = new int[nodes.Max() + 1];
            nodes.ForEach(node => parents[node] = node);                          //initialize forest as self parent graphs

            List<Edge> sortedEdges = graph.Edges.OrderBy(e => e.Time).ToList();
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

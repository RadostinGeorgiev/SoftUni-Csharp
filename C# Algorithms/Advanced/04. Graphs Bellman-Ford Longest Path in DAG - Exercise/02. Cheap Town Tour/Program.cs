﻿namespace _02._Cheap_Town_Tour
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
        private int VerticesCount { get; set; }
        private int EdgesCount { get; set; }
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
            int towns = int.Parse(Console.ReadLine());
            int streets = int.Parse(Console.ReadLine());

            Graph graph = new Graph(towns, streets);
            graph = ReadGraphFromConsole(graph, streets);

            List<Edge> forest = MSTKruskal(graph);

            Console.WriteLine($"Total cost: {forest.Sum(x=>x.Weight)}");
        }

        private static Graph ReadGraphFromConsole(Graph graph, int edges)
        {
            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                                        .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
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

        private static List<Edge> MSTKruskal(Graph graph)                           //Minimum Spanning Tree - Kruskal’s algorithm 
        {
            List<Edge> forest = new List<Edge>();

            List<int> nodes = graph.Edges                                           //get Graph's nodes from edge's structure
                            .Select(e => e.First)
                            .Union(graph.Edges.Select(e => e.Second))
                            .Distinct()
                            .ToList();

            parents = new int[nodes.Max() + 1];
            nodes.ForEach(node => parents[node] = node);                        //initialize forest as self parent graphs

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

        private static int FindRoot(int node)
        {
            while (parents[node] != node)
            {
                node = parents[node];
            }

            return node;
        }
    }
}

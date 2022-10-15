namespace _02._Creep
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Length { get; set; }                               //Weight

        public override string ToString()
        {
            //return string.Format($"{this.First} -> {this.Second} ({this.Length})");
            return string.Format($"{this.First} {this.Second}");
        }
    }
    class Graph
    {
        public int VerticesCount { get; set; }
        public int EdgesCount { get; set; }
        public Dictionary<int, List<Edge>> Edges;

        public Graph(int verticesCount, int edgesCount)
        {
            this.VerticesCount = verticesCount;
            this.EdgesCount = edgesCount;

            this.Edges = new Dictionary<int, List<Edge>>();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var tumors = int.Parse(Console.ReadLine());
            var vines = int.Parse(Console.ReadLine());

            var graph = new Graph(tumors, vines);
            graph = ReadEdgesGraphFromConsole(graph, vines);

            var MST = MSTPrim(graph);                                                           //Kruskal’s Algorithm is slow for this task
            var totalTime = MST.Sum(x => x.Length);

            Console.WriteLine(string.Join(Environment.NewLine, MST));
            Console.WriteLine($"{totalTime}");
        }

        private static Graph ReadEdgesGraphFromConsole(Graph graph, int edges)
        {
            for (var i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToArray();

                var from = edgeData[0];
                var to = edgeData[1];
                var length = edgeData[2];

                if (!graph.Edges.ContainsKey(from))
                {
                    graph.Edges.Add(from, new List<Edge>());
                }
                if (!graph.Edges.ContainsKey(to))
                {
                    graph.Edges.Add(to, new List<Edge>());
                }

                var newFirstEdge = graph.Edges[from].FirstOrDefault(x => x.First == from && x.Second == to);
                var newSecondEdge = graph.Edges[to].FirstOrDefault(x => x.First == from && x.Second == to);

                if (newFirstEdge != null)
                {
                    newFirstEdge.Length = length;
                }
                else if (newSecondEdge != null)
                {
                    newSecondEdge.Length = length;
                }
                else
                {
                    var newEdge = new Edge
                    {
                        First = from,
                        Second = to,
                        Length = length,
                    };

                    graph.Edges[from].Add(newEdge);
                    graph.Edges[to].Add(newEdge);
                }
            }

            return graph;
        }

        private static List<Edge> MSTPrim(Graph graph)
        {
            var spanningTree = new List<Edge>();
            HashSet<int> spanningTreeNodes = new HashSet<int>();

            foreach (var node in graph.Edges.Keys)
            {
                if (!spanningTreeNodes.Contains(node))
                {
                    Prim(graph, node, spanningTree, spanningTreeNodes);
                }
            };

            return spanningTree;

        }

        private static void Prim(Graph graph, int startNode, List<Edge> spanningTree, HashSet<int> spanningTreeNodes)
        {
            var priorityQueue = new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Length - s.Length));

            spanningTreeNodes.Add(startNode);                              //add startNode in spanningTree
            priorityQueue.AddMany(graph.Edges[startNode]);            //add startNode edge in queue

            while (priorityQueue.Count != 0)
            {
                var minEdge = priorityQueue.RemoveFirst();                      //get edge with min weight from queue
                int nonTreeNode = -1;                                           //check if nodes of this edge are part of the tree
                
                if (spanningTreeNodes.Contains(minEdge.First) &&
                    !spanningTreeNodes.Contains(minEdge.Second))
                {
                    nonTreeNode = minEdge.Second;
                }
                if (spanningTreeNodes.Contains(minEdge.Second) &&
                    !spanningTreeNodes.Contains(minEdge.First))
                {
                    nonTreeNode = minEdge.First;
                }

                if (nonTreeNode != -1)                                          //if we have only one node as part of the tree:
                {
                    spanningTree.Add(minEdge);                             //add edge in spanning tree 

                    spanningTreeNodes.Add(nonTreeNode);                     //add this edge to the tree
                    priorityQueue.AddMany(graph.Edges[nonTreeNode]);  //add edges of the nonTree node to the queue 
                }
            }
        }
    }
}

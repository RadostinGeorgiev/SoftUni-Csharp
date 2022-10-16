namespace _01._Most_Reliable_Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Weight { get; set; }

        public Edge()
        {
            First = Second = Weight = 0;
        }

        public override string ToString()
        {
            return string.Format($"({this.First}-{this.Second}) -> {this.Weight}");
        }
    }

    class Graph
    {
        private int VerticesCount { get; set; }
        public int EdgesCount { get; set; }
        public Dictionary<int, List<Edge>> Nodes;

        public Graph(int verticesCount, int edgesCount)
        {
            this.VerticesCount = verticesCount;
            this.EdgesCount = edgesCount;

            Nodes = new Dictionary<int, List<Edge>>(verticesCount);
        }
    }

    internal class Program
    {
        static int[] parents;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            Graph graph = new Graph(nodes, edges);
            graph = ReadGraphFromConsole(graph);

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            double[] distance = Dijkstra(graph, source, destination); //Used modified Dijkstra's Algorithm

            if (double.IsNegativeInfinity(distance[destination]))
            {
                Console.WriteLine("There is no such path.");
            }
            else
            {
                var path = GetPath(destination);

                Console.WriteLine($"Most reliable path reliability: {distance[destination]:F2}%");
                Console.WriteLine(string.Join(" -> ", path));
            }
        }

        private static Graph ReadGraphFromConsole(Graph graph)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                                      .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();

                int first = edgeData[0];
                int second = edgeData[1];

                if (!graph.Nodes.ContainsKey(first))
                {
                    graph.Nodes.Add(first, new List<Edge>());
                }

                if (!graph.Nodes.ContainsKey(second))
                {
                    graph.Nodes.Add(second, new List<Edge>());
                }

                graph.Nodes[first].Add(new Edge
                {
                    First = first,
                    Second = second,
                    Weight = edgeData[2],
                });

                graph.Nodes[second].Add(new Edge
                {
                    First = first,
                    Second = second,
                    Weight = edgeData[2],
                });
            }

            return graph;
        }

        private static double[] Dijkstra(Graph graph, int source, int destination)
        {
            double[] reliability = new double[graph.Nodes.Keys.Max() + 1];
            Array.Fill(reliability, double.NegativeInfinity);            //init all reliabilities with negative infinity - we search max value

            reliability[source] = 100;

            parents = new int[graph.Nodes.Keys.Max() + 1];
            Array.Fill(parents, -1);

            //priority queue holding nodes ordered by reliability r[]
            OrderedBag<int> priorityQueue = new OrderedBag<int>(Comparer<int>
               .Create((f, s) => reliability[f].CompareTo(reliability[s])));
            priorityQueue.Add(source);                                         //add start node to queue

            while (priorityQueue.Count != 0)
            {
                var maxNode = priorityQueue.First();                            //dequeue the largest node from Q
                priorityQueue.Remove(maxNode);

                if (double.IsNegativeInfinity(reliability[maxNode]))              //we have a node without available path
                {
                    break;
                }

                if (maxNode == destination)                                         //if we have known end node
                {
                    break;
                }

                foreach (var edge in graph.Nodes[maxNode])
                {
                    int otherNode = edge.First == maxNode                           //get the child of current node - node from edge, not included in visited part of graph
                            ? edge.Second
                            : edge.First;

                    if (double.IsNegativeInfinity(reliability[otherNode]))        //if new node is not visited 
                    {
                        priorityQueue.Add(otherNode);
                    }

                    double newReliability = reliability[maxNode] * edge.Weight / 100;   //calculate new reliability to current node

                    if (newReliability > reliability[otherNode])
                    {
                        reliability[otherNode] = newReliability;                    //update reliability with better value
                        parents[otherNode] = maxNode;                               //set parent of the node with best reliability

                        priorityQueue = new OrderedBag<int>(priorityQueue,
                            Comparer<int>.Create((f, s) => reliability[s].CompareTo(reliability[f]))); //reorder queue
                    }
                }
            }

            return reliability;
        }

        private static Stack<int> GetPath(int node)
        {
            Stack<int> path = new Stack<int>();

            while (node != -1)
            {
                path.Push(node);
                node = parents[node];
            }

            return path;
        }
    }
}
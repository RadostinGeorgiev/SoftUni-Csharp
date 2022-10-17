namespace Dijkstra_and_MST___Lab
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

        public override string ToString()
        {
            return string.Format($"({this.First}-{this.Second}) -> {this.Weight}");
        }
    }

    class Graph
    {
        public Dictionary<int, List<Edge>> Edges;
        public int EdgesCount { get; set; }

        public Graph(int edgesCount)
        {
            this.EdgesCount = edgesCount;

            Edges = new Dictionary<int, List<Edge>>();
        }
    }

    internal class Program
    {
        static Dictionary<int, List<Edge>> graph;

        static int startNode;
        static int endNode;

        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Graph graph = new Graph(number);
            graph = ReadEdgesGraphFromConsole(graph);

            startNode = int.Parse(Console.ReadLine());
            endNode = int.Parse(Console.ReadLine());

            var distances = Dijkstra(graph, startNode, endNode, out int[] parents);

            Console.WriteLine(double.IsPositiveInfinity(distances[endNode])
                ? "There is no such path."
                : $"{distances[endNode]}{Environment.NewLine}" +
                $"{string.Join(" ", GetPath(parents, endNode))}");
        }

        private static Graph ReadEdgesGraphFromConsole(Graph graph)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                                      .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();

                int firstNode = edgeData[0];
                int secondNode = edgeData[1];

                if (!graph.Edges.ContainsKey(firstNode))
                {
                    graph.Edges.Add(firstNode, new List<Edge>());
                }

                if (!graph.Edges.ContainsKey(secondNode))
                {
                    graph.Edges.Add(secondNode, new List<Edge>());
                }

                var edge = new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = edgeData[2],
                };

                graph.Edges[firstNode].Add(edge);
                graph.Edges[secondNode].Add(edge);
            }

            return graph;
        }

        //Dijkstra's Algorithm O((V+E).logV)
        private static double[]
            Dijkstra(Graph graph, int startNode, int endNode, out int[] parents)    //return distances array
        {
            double[] distances = new double[graph.Edges.Keys.Max() + 1];
            parents = new int[graph.Edges.Keys.Max() + 1];
            distances[startNode] = 0;

            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = double.PositiveInfinity;
                parents[i] = -1;
            }

            //priority queue holding nodes ordered by distance d[]
            var priorityQueue =
                new OrderedBag<int>(Comparer<int>.Create((f, s) => distances[f].CompareTo(distances[s])));
            priorityQueue.Add(startNode);                                      //add start node to queue

            while (priorityQueue.Count != 0)
            {
                var minNode = priorityQueue.RemoveFirst();                      //dequeue the smallest node from Q

                if (double.IsPositiveInfinity(distances[minNode]))                //we have a node without available path
                {
                    break;
                }

                if (minNode == endNode)                                             //if we have known end node
                {
                    break;
                }

                foreach (var edge in graph.Edges[minNode])
                {
                    int otherNode = edge.First == minNode                           //get the child of current node - node from edge, not included in visited part of graph
                            ? edge.Second
                            : edge.First;

                    if (double.IsPositiveInfinity(distances[otherNode]))          //if new node is not visited 
                    {
                        priorityQueue.Add(otherNode);
                    }

                    double newDistance = distances[minNode] + edge.Weight;          //calculate new distance to current node

                    if (newDistance < distances[otherNode])
                    {
                        distances[otherNode] = newDistance;                         //update distance with shortest value
                        parents[otherNode] = minNode;                               //set parrent of the node with best distance

                        priorityQueue =
                            new OrderedBag<int>(priorityQueue, Comparer<int>
                               .Create((f, s) => distances[f].CompareTo(distances[s]))); //reorder queue
                    }
                }
            }

            return distances;
        }

        private static Stack<int> GetPath(int[] previous, int node)
        {
            Stack<int> path = new Stack<int>();

            while (node != -1)
            {
                path.Push(node);
                node = previous[node];
            }

            return path;
        }
    }
}
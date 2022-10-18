namespace _01._Dora_the_Explorer
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
            int cities = int.Parse(Console.ReadLine());                           //nodes
            int streets = cities;

            Graph graph = new Graph(cities, streets);
            graph = ReadEdgesGraphFromConsole(graph);

            int spendMinutesInCity = int.Parse(Console.ReadLine());
            int startCity = int.Parse(Console.ReadLine());                        //startNode
            int endCity = int.Parse(Console.ReadLine());                          //endNode

            double[] distances = Dijkstra(graph, startCity, endCity, spendMinutesInCity, out int[] parents);

            Console.WriteLine($"Total time: {distances[endCity]}");
            Console.WriteLine(string.Join(Environment.NewLine, GetPath(parents, endCity)));
        }

        private static Graph ReadEdgesGraphFromConsole(Graph graph)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                int[] edgeData = Console.ReadLine()
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

                Edge edge = new Edge
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

        private static double[] Dijkstra(Graph graph, int startNode, int endNode, int pause, out int[] parents) //return distances array
        {
            double[] distance = new double[graph.Edges.Keys.Max() + 1];
            parents = new int[graph.Edges.Keys.Max() + 1];

            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = double.PositiveInfinity;                              //init all distances with positive infinity
                parents[i] = -1;
            }

            distance[startNode] = 0;

            //priority queue holding nodes ordered by distance d[]
            OrderedBag<int> priorityQueue = new OrderedBag<int>(
                Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s])));
            priorityQueue.Add(startNode);                                      //add start node to queue

            while (priorityQueue.Count != 0)
            {
                int minNode = priorityQueue.First();                                //dequeue the smallest node from Q
                priorityQueue.Remove(minNode);

                if (double.IsPositiveInfinity(distance[minNode]))                 //we have a node without available path
                {
                    break;
                }

                if (minNode == endNode)                                             //if we have known end node
                {
                    break;
                }

                foreach (Edge edge in graph.Edges[minNode])
                {
                    int otherNode = edge.First == minNode                           //get the child of current node - node from edge, not included in visited part of graph
                            ? edge.Second
                            : edge.First;

                    if (double.IsPositiveInfinity(distance[otherNode]))           //if new node is not visited 
                    {
                        priorityQueue.Add(otherNode);
                    }

                    if (otherNode == endNode)
                    {
                        pause = 0;
                    }

                    double newDistance =
                        distance[minNode] + edge.Weight + pause;                    //calculate new distance to current node

                    if (newDistance < distance[otherNode])
                    {
                        distance[otherNode] = newDistance;                          //update distance with shortest value
                        parents[otherNode] = minNode;                               //set parent of the node with best distance

                        priorityQueue = new OrderedBag<int>(priorityQueue,
                            Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s]))); //reorder queue
                    }
                }
            }

            return distance;
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
namespace _01._Trains_Part_Two
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
        public int VerticesCount;
        public int EdgesCount;
        public Dictionary<int, List<Edge>> Edges;

        public Graph(int verticesCount, int edgesCount)
        {
            this.VerticesCount = verticesCount;
            this.EdgesCount = edgesCount;

            Edges = new Dictionary<int, List<Edge>>();
        }
    }
    internal class Program
    {
        private static double[] distance;
        private static int[] parents;

        static void Main(string[] args)
        {
            int depots = int.Parse(Console.ReadLine());                       //nodes
            int tracks = int.Parse(Console.ReadLine());                       //edges

            int[] direction = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int start = direction[0];                                           //startNode
            int end = direction[1];                                             //endNode

            Graph graph = new Graph(depots, tracks);
            graph = ReadEdgesGraphFromConsole(graph);

            distance = new double[graph.Edges.Keys.Count];
            parents = new int[graph.Edges.Keys.Count];

            for (int i = 0; i < parents.Length; i++)
            {
                distance[i] = double.PositiveInfinity;
                parents[i] = -1;
            }

            distance[start] = 0;


            var distances = Dijkstra(graph, start, end);

            Console.WriteLine(string.Join(" ", GetPath(parents, end)));
            Console.WriteLine(distances[end]);
        }

        private static Graph ReadEdgesGraphFromConsole(Graph graph)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                                        .Split()
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
        private static double[] Dijkstra(Graph graph, int startNode, int endNode)    //return distances array
        {
            //priority queue holding nodes ordered by distance d[]
            var priorityQueue = new OrderedBag<int>(Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s])));
            priorityQueue.Add(startNode);                              //add start node to queue

            while (priorityQueue.Count > 0)
            {
                int minNode = priorityQueue.RemoveFirst();                        //dequeue the smallest node from Q

                if (double.IsPositiveInfinity(distance[minNode]))         //we have a node without available path
                {
                    break;
                }

                if (minNode == endNode)                                     //if we have known end node
                {
                    break;
                }

                foreach (var edge in graph.Edges[minNode])
                {
                    int otherNode = edge.First == minNode                   //get the child of current node - node from edge, not included in visited part of graph
                        ? edge.Second
                        : edge.First;

                    if (double.IsPositiveInfinity(distance[otherNode]))     //if new node is not visited 
                    {
                        priorityQueue.Add(otherNode);
                    }

                    double newDistance = distance[minNode] + edge.Weight;   //calculate new distance to current node

                    if (newDistance < distance[otherNode])
                    {
                        distance[otherNode] = newDistance;                  //update distance with shortest value
                        parents[otherNode] = minNode;                       //set parent of the node with best distance

                        priorityQueue =
                            new OrderedBag<int>(priorityQueue, Comparer<int>
                                .Create((f, s) => distance[f].CompareTo(distance[s]))); //reorder queue
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

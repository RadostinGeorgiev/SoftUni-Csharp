namespace _01._Dora_the_Explorer
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
        static int[] parents;
        static void Main(string[] args)
        {
            int cities = int.Parse(Console.ReadLine());                       //nodes
            int streets = cities;

            Graph graph = new Graph(cities, streets);
            graph = ReadEdgesGraphFromConsole(graph);

            int spendMinutesInCity = int.Parse(Console.ReadLine());
            int startCity = int.Parse(Console.ReadLine());                    //startNode
            int endCity = int.Parse(Console.ReadLine());                      //endNode

            var distances = Dijkstra(graph, startCity, endCity, spendMinutesInCity);

            Console.WriteLine($"Total time: {distances[endCity]}");
            Console.WriteLine(string.Join(Environment.NewLine, GetPath(endCity)));
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

                var edge = new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = edgeData[2],
                };

                if (!graph.Edges.ContainsKey(firstNode))
                {
                    graph.Edges.Add(firstNode, new List<Edge>());
                }
                if (!graph.Edges.ContainsKey(secondNode))
                {
                    graph.Edges.Add(secondNode, new List<Edge>());
                }

                graph.Edges[firstNode].Add(edge);
                graph.Edges[secondNode].Add(edge);
            }

            return graph;
        }
        private static double[] Dijkstra(Graph graph, int startNode, int endNode, int pause)
        {
            double[] distance = new double[graph.Edges.Keys.Max() + 1];
            Array.Fill(distance, double.PositiveInfinity);                 //init all distances with positive infinity

            distance[startNode] = 0;

            parents = new int[graph.Edges.Keys.Max() + 1];
            Array.Fill(parents, -1);

            //priority queue holding nodes ordered by distance d[]
            var priorityQueue = new SortedSet<int>(
                Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s])));
            priorityQueue.Add(startNode);                                   //add start node to queue

            while (priorityQueue.Count != 0)
            {
                int minNode = priorityQueue.First();                            //dequeue the smallest node from Q
                priorityQueue.Remove(minNode);

                if (double.IsPositiveInfinity(distance[minNode]))           //we have a node without available path
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

                    if (otherNode == endNode)
                    {
                        pause = 0;
                    }
                    double newDistance = distance[minNode] + edge.Weight + pause;   //calculate new distance to current node

                    if (newDistance < distance[otherNode])
                    {
                        distance[otherNode] = newDistance;                  //update distance with shortest value
                        parents[otherNode] = minNode;                       //set parrent of the node with best distance

                        priorityQueue = new SortedSet<int>(priorityQueue,
                            Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s]))); //reorder queue
                    }
                }
            }

            return distance;
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

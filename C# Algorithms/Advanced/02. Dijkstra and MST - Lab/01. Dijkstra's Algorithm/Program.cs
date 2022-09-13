namespace Dijkstra_and_MST___Lab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Weight { get; set; }
    }

    internal class Program
    {
        static Dictionary<int, List<Edge>> graph;

        static int startNode;
        static int endNode;

        static int[] parents;
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            CreateNodeEdgesGraphFromConsole(number);

            startNode = int.Parse(Console.ReadLine());
            endNode = int.Parse(Console.ReadLine());

            Dijkstra();
        }

        private static void CreateNodeEdgesGraphFromConsole(int edges)
        {
            graph = new Dictionary<int, List<Edge>>();

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
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

                if (!graph.ContainsKey(firstNode))
                {
                    graph.Add(firstNode, new List<Edge>());
                }
                if (!graph.ContainsKey(secondNode))
                {
                    graph.Add(secondNode, new List<Edge>());
                }

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);
            }
        }

        private static void Dijkstra()
        {
            double[] distance = new double[graph.Keys.Max() + 1];
            Array.Fill(distance, double.PositiveInfinity);                 //init all distances with positive infinity

            distance[startNode] = 0;

            parents = new int[graph.Keys.Max() + 1];
            Array.Fill(parents, -1);

            //priority queue holding nodes ordered by distance d[]
            var priorityQueue = new SortedSet<int>(
                Comparer<int>.Create((f, s) => (int)(distance[f] - distance[s])));
            priorityQueue.Add(startNode);                                   //add start node to queue

            while (priorityQueue.Count != 0)
            {
                var minNode = priorityQueue.Min;                  //dequeue the smallest node from Q
                priorityQueue.Remove(minNode);

                if (double.IsPositiveInfinity(distance[minNode]))           //we have a node without available path
                {
                    break;
                }

                foreach (var edge in graph[minNode])
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
                        parents[otherNode] = minNode;                       //set parrent of the node with best distance

                        priorityQueue = new SortedSet<int>(priorityQueue,
                            Comparer<int>.Create((f, s) => (int)(distance[f] - distance[s]))); //reorder queue
                    }
                }
            }

            if (double.IsPositiveInfinity(distance[endNode]))
            {
                Console.WriteLine("There is no such path.");
            }
            else
            {
                Console.WriteLine(distance[endNode]);
                GetPath(endNode);
            }
        }
        private static void GetPath(int node)
        {
            Stack<int> path = new Stack<int>();

            while (node != -1)
            {
                path.Push(node);
                node = parents[node];
            }

            Console.WriteLine(string.Join(" ", path));
        }
    }
}

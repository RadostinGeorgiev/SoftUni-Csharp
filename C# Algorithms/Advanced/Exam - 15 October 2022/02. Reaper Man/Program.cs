namespace _02._Reaper_Man
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

            Edges = new Dictionary<int, List<Edge>>(verticesCount);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int blocked = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            int[] destination = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int start = destination[0];
            int end = destination[1];

            Graph graph = new Graph(blocked, edges);
            graph = ReadGraphFromConsole(graph);

            var distances = Dijkstra(graph, start, end, out int[] parents);

            var path = GetPath(parents, end);
            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine(distances[end]);
        }

        private static Graph ReadGraphFromConsole(Graph graph)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToArray();

                int first = edgeData[0];
                int second = edgeData[1];
                int weight = edgeData[2];

                if (!graph.Edges.ContainsKey(first))
                {
                    graph.Edges.Add(first, new List<Edge>());
                }

                if (!graph.Edges.ContainsKey(second))
                {
                    graph.Edges.Add(second, new List<Edge>());
                }

                var newFirstEdge = graph.Edges[first].FirstOrDefault(x => x.First == first && x.Second == second);
                var newSecondEdge = graph.Edges[second].FirstOrDefault(x => x.First == first && x.Second == second);

                if (newFirstEdge != null)
                {
                    newFirstEdge.Weight = weight;
                    newSecondEdge.Weight = weight;
                }
                else
                {
                    graph.Edges[first].Add(new Edge
                    {
                        First = first,
                        Second = second,
                        Weight = edgeData[2],
                    });

                    graph.Edges[second].Add(new Edge
                    {
                        First = first,
                        Second = second,
                        Weight = edgeData[2],
                    });
                }

            }

            return graph;
        }

        private static int[] Dijkstra(Graph graph, int startNode, int endNode, out int[] parents)
        {
            int[] distance = new int[graph.Edges.Keys.Max() + 1];
            parents = new int[graph.Edges.Keys.Max() + 1];

            for (int i = 0; i < parents.Length; i++)
            {
                distance[i] = int.MaxValue;
                parents[i] = -1;
            }

            distance[startNode] = 0;

            //priority queue holding nodes ordered by distance d[]
            var priorityQueue = new OrderedBag<int>(Comparer<int>
                .Create((f, s) => distance[f].CompareTo(distance[s]))); priorityQueue.Add(startNode);                              //add start node to queue

            while (priorityQueue.Count != 0)
            {
                int minNode = priorityQueue.First();                        //dequeue the smallest node from Q
                priorityQueue.Remove(minNode);

                if (distance[minNode] == int.MaxValue)         //we have a node without available path
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

                    if (distance[otherNode] == int.MaxValue)            //if new node is not visited 
                    {
                        priorityQueue.Add(otherNode);
                    }

                    int newDistance = distance[minNode] + edge.Weight;   //calculate new distance to current node

                    if (newDistance < distance[otherNode])
                    {
                        distance[otherNode] = newDistance;                  //update distance with shortest value
                        parents[otherNode] = minNode;                       //set parent of the node with best distance

                        priorityQueue =
                            new OrderedBag<int>(priorityQueue, Comparer<int>
                                .Create((f, s) => distance[f].CompareTo(distance[s])));
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

namespace _02._Robbery
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
        public int EdgesCount;
        public Dictionary<int, List<Edge>> Edges;

        public Graph(int edgesCount)
        {
            this.EdgesCount = edgesCount;

            Edges = new Dictionary<int, List<Edge>>();
        }
    }
    internal class Program
    {
        static int[] parents;
        static void Main(string[] args)
        {
            int points = int.Parse(Console.ReadLine());                       //nodes
            int connections = int.Parse(Console.ReadLine());                  //edges

            Graph graph = new Graph(connections);
            graph = ReadEdgesGraphFromConsole(graph);

            List<int> watchedPoints = new List<int>();
            string[] colors = Console.ReadLine().Split();

            for (int i = 0; i < colors.Length; i++)
            {
                string color = colors[i];
                if (color[color.Length - 1] == 'w')
                {
                    watchedPoints.Add(i);
                }
            }

            int startPoint = int.Parse(Console.ReadLine());            //startNode
            int endPoint = int.Parse(Console.ReadLine());              //endNode

            var distances = Dijkstra(graph, startPoint, endPoint, watchedPoints);

            Console.WriteLine(distances[endPoint]);
            //Console.WriteLine(string.Join("->", GetPath(endPoint)));
        }

        private static Graph ReadEdgesGraphFromConsole(Graph graph)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToArray();

                int start = edgeData[0];
                int end = edgeData[1];

                var edge = new Edge
                {
                    First = start,
                    Second = end,
                    Weight = edgeData[2],
                };

                if (!graph.Edges.ContainsKey(start))
                {
                    graph.Edges.Add(start, new List<Edge>());
                }
                if (!graph.Edges.ContainsKey(end))
                {
                    graph.Edges.Add(end, new List<Edge>());
                }

                graph.Edges[start].Add(edge);
                graph.Edges[end].Add(edge);
            }

            return graph;
        }
        private static double[] Dijkstra(Graph graph, int startNode, int endNode, List<int> watchedPoints)
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

            while (priorityQueue.Count > 0)
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

                    if (watchedPoints.Contains(otherNode))
                    {
                        continue;
                    }

                    if (double.IsPositiveInfinity(distance[otherNode]))     //if new node is not visited 
                    {
                        priorityQueue.Add(otherNode);
                    }

                    double newDistance = distance[minNode] + edge.Weight;   //calculate new distance to current node

                    if (newDistance < distance[otherNode])
                    {
                        distance[otherNode] = newDistance;                  //update distance with shortest value
                        parents[otherNode] = minNode;                       //set parent of the node with best distance

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

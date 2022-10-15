namespace _02._Data_Transfer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Edge
    {
        internal Edge Residual;                                      //Pointer to residual(reverse) edge
        public int First { get; set; }
        public int Second { get; set; }
        public int Flow { get; set; }
        public int Capacity { get; set; }
        public Edge()
        {
            this.First = this.Second = this.Capacity = this.Capacity = 0;
        }
        public Edge(int first, int second, int flow, int capacity)
        {
            this.First = first;
            this.Second = second;
            this.Flow = flow;
            this.Capacity = capacity;
        }
        public override string ToString()
        {
            return string.Format($"({this.First}-{this.Second}) -> {this.Flow}/{this.Capacity}");
        }
    }
    class Graph
    {
        public int VerticesCount;
        public int EdgesCount;

        public List<Edge>[] Edges;

        public Graph(int verticesCount, int edgesCount)
        {
            this.VerticesCount = verticesCount;
            this.EdgesCount = edgesCount;
            this.Edges = new List<Edge>[VerticesCount];

            for (int node = 0; node < this.VerticesCount; node++)
            {
                this.Edges[node] = new List<Edge>();
            }
        }
        public void Connect(int u, int v, int capacity)                                     //automatically create the residual edges
        {
            Edge edge = new Edge(u, v, 0, capacity);
            Edge residual = new Edge(v, u, 0, 0);                   //residual is auxiliary edge that allows us to solve the problem

            edge.Residual = residual;                                                       //pointer from each edge to its reverse edge and vice versa
            residual.Residual = edge;

            Edges[u].Add(edge);
            Edges[v].Add(residual);
        }
    }

    internal class Program
    {
        private static Graph graph;
        private static Edge[] visited;
        static void Main(string[] args)
        {
            int devices = int.Parse(Console.ReadLine());
            int connections = int.Parse(Console.ReadLine());
            int[] transfer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int source = transfer[0];                                            //startNode
            int destination = transfer[1];                                       //endNode

            graph = new Graph(devices, connections);
            graph = ReadGraphNodesFromConsole(graph);

            var maxFlow = ReconstructPath(source, destination);
            Console.WriteLine($"{maxFlow}");
        }

        private static Graph ReadGraphNodesFromConsole(Graph graph)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int start = edgeData[0];
                int end = edgeData[1];

                int capacity = edgeData[2]; ;

                if (capacity > 0)
                {
                    graph.Connect(start, end, capacity);
                }
            }
            return graph;
        }
        private static bool Bfs(int source, int destination)
        {
            //Returns true if there is a path from source to destination in graph. 
            //Also fills visited[] to store the path

            visited = new Edge[graph.VerticesCount];          //visited array used for storing path - visited[i] stores edge used to reach node i
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(source);

            while (queue.Count > 0 && visited[destination] == null)  //BFS finding shortest augmenting path
            {
                int node = queue.Dequeue();

                foreach (var edge in graph.Edges[node])
                {
                    if (visited[edge.Second] == null &&              //checks that edge has not yet been visited,
                        edge.Second != source &&                     //and it doesn't point to the source,
                        edge.Capacity - edge.Flow > 0)               //and it is possible to send flow through it     
                    {
                        queue.Enqueue(edge.Second);
                        visited[edge.Second] = edge;
                    }
                }
            }

            return visited[destination] != null;                    //return whether a path was found
        }
        private static int GetMinFlow(int source, int destination)
        {
            //Find Minimum residual flow through path filled by BFS
            int minFlow = int.MaxValue;

            for (Edge edge = visited[destination]; edge != null; edge = visited[edge.First])
            {
                minFlow = Math.Min(minFlow, edge.Capacity - edge.Flow);
            }

            return minFlow;
        }
        private static void UpdateFlow(int source, int destination, int flow)
        {
            // Adds to flow values and subtracts from reverse flow values in path
            for (Edge edge = visited[destination]; edge != null; edge = visited[edge.First])
            {
                edge.Flow += flow;
                edge.Residual.Flow -= flow;
            }
        }
        private static int ReconstructPath(int source, int destination)
        {
            // Returns tne maximum flow from source to destination in the given graph
            int maxFlow = 0;

            while (Bfs(source, destination))
            {
                // Finds maximum flow that can be pushed through path filled by BFS
                // by finding the Minimum residual flow of every edge in the path
                int minFlow = GetMinFlow(source, destination);

                UpdateFlow(source, destination, minFlow);
                maxFlow += minFlow;
            }

            return maxFlow;
        }
    }
}

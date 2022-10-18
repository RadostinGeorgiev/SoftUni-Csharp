namespace _02._Pipelines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Graph
    {
        private int VerticesCount { get; set; }
        public int[,] Nodes;

        public Graph(int verticesCount)
        {
            this.VerticesCount = verticesCount;
            this.Nodes = new int[verticesCount, verticesCount];
        }
    }

    internal class Program
    {
        private static int agents;
        private static int pipelines;
        private static List<string> agentNames;
        private static List<string> pipelineNames;

        private static Graph graph;
        private static int[] parents;
        private static int nodes;

        static void Main(string[] args)
        {
            agents = int.Parse(Console.ReadLine());
            pipelines = int.Parse(Console.ReadLine());
            agentNames = new List<string>(agents);

            for (int i = 0; i < agents; i++)
            {
                agentNames.Add(Console.ReadLine());
            }

            pipelineNames = new List<string>(pipelines);

            for (int i = 0; i < pipelines; i++)
            {
                pipelineNames.Add(Console.ReadLine());
            }

            //Graph => Source, Agent1, Agent2, .. AgentN, Pipeline1, Pipeline2, ... PipelineN, Destination
            //Graph => Source, Agent, Pipelines, Destination
            //Graph.nodes => Agent + Pipelines + 2
            nodes = agents + pipelines + 2;
            graph = new Graph(nodes);
            graph = CreateGraphFromConsole();

            parents = new int[nodes];
            Array.Fill(parents, -1);

            int source = 0;
            int destination = nodes - 1;

            ReconstructPath(source, destination);

            GetMaximumAssignment();

            //GetMaximumAssignmentBfs(source, destination);
            //Console.WriteLine($"Max flow = {maxFlow}");
        }

        private static void GetMaximumAssignment()
        {
            SortedSet<string> result = new SortedSet<string>();

            for (int pipeline = agents + 1; pipeline <= agents + pipelines; pipeline++)
            {
                for (int index = 0; index < graph.Nodes.GetLength(1); index++)
                {
                    if (graph.Nodes[pipeline, index] > 0)
                    {
                        result.Add($"{agentNames[index - 1]} - {pipelineNames[pipeline - agents - 1]}");
                    }
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, result));
        }

        private static void GetMaximumAssignmentBfs(int source, int destination)
        {
            SortedSet<string> result = new SortedSet<string>();
            bool[] visited = new bool[nodes];
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(destination);
            visited[destination] = true;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                for (int child = 0; child < graph.Nodes.GetLength(1); child++)
                {
                    if (!visited[child] && graph.Nodes[node, child] == 1)
                    {
                        queue.Enqueue(child);
                        visited[child] = true;

                        if (node != source && node != destination &&
                            child != source && child != destination)
                        {
                            result.Add($"{agentNames[child - 1]} - {pipelineNames[node - agents - 1]}");
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        private static Graph CreateGraphFromConsole()
        {
            for (int agent = 1; agent <= agents; agent++)
            {
                graph.Nodes[0, agent] = 1;
            }

            for (int pipeline = agents + 1; pipeline <= agents + pipelines; pipeline++)
            {
                graph.Nodes[pipeline, nodes - 1] = 1;
            }

            for (int agent = 1; agent <= agents; agent++)
            {
                List<string> connections = Console.ReadLine().Split(", ").ToList();
                int agentIndex = agentNames.IndexOf(connections[0]) + 1;

                for (int pipeline = 1; pipeline < connections.Count; pipeline++)
                {
                    int pipelineIndex = pipelineNames.IndexOf(connections[pipeline]);
                    graph.Nodes[agentIndex, agents + pipelineIndex + 1] = 1;
                }
            }

            return graph;
        }

        private static bool Bfs(int source, int destination)
        {
            bool[] visited = new bool[nodes];
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(source);
            visited[source] = true;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                for (int child = 0; child < graph.Nodes.GetLength(1); child++)
                {
                    if (!visited[child] && graph.Nodes[node, child] == 1)
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                        parents[child] = node;
                    }
                }
            }

            return visited[destination];
        }

        private static void UpdateFlow(int source, int destination, int flow)
        {
            int node = destination;

            while (node != source)
            {
                int parent = parents[node];
                graph.Nodes[parent, node] -= flow;
                graph.Nodes[node, parent] += flow;
                node = parent;
            }
        }

        private static void ReconstructPath(int source, int destination)
        {
            int maxFlow = 0;

            while (Bfs(source, destination))
            {
                UpdateFlow(source, destination, 1);
                maxFlow += 1;
            }
        }

        public static void PrintGraph(Graph graph)
        {
            for (int row = 0; row < graph.Nodes.GetLength(0); row++)
            {
                for (int col = 0; col < graph.Nodes.GetLength(1); col++)
                {
                    Console.Write($"{graph.Nodes[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
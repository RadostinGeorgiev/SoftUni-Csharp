namespace _03._Find_Bi_Connected_Components
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;

    class Graph
    {
        public int VerticesCount;
        public List<int>[] nodes;

        public Graph(int verticesCount)
        {
            this.VerticesCount = verticesCount;
            this.nodes = new List<int>[VerticesCount];

            for (int node = 0; node < this.nodes.Length; node++)
            {
                this.nodes[node] = new List<int>();
            }
        }
    }
    internal class Program
    {
        private static int[] depths;
        private static int[] lowpoints;
        private static bool[] visited;
        private static int[] parents;

        private static List<int> articulationPoints;
        private static Stack<int> stack;
        private static List<HashSet<int>> components;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            Graph graph = new Graph(nodes);
            graph = ReadGraphNodesFromConsole(graph, edges);

            depths = new int[nodes];
            lowpoints = new int[nodes];
            visited = new bool[nodes];
            parents = new int[nodes];
            Array.Fill(parents, -1);

            articulationPoints = new List<int>();
            stack = new Stack<int>();
            components = new List<HashSet<int>>();

            for (int node = 0; node < graph.nodes.Length; node++)
            {
                if (!visited[node])
                {
                    FindArticulationPointsDfs(graph, node, 1);
                }
            }

            //Console.WriteLine($"Articulation points: {string.Join(", ", articulationPoints)}");

            components.Add(stack.ToHashSet());

            //foreach (var component in components)
            //{
            //    Console.WriteLine($"{{{string.Join(", ", component)}}}");
            //}
            Console.WriteLine($"Number of bi-connected components: {components.Count}");
        }

        private static Graph ReadGraphNodesFromConsole(Graph graph, int edges)
        {
            for (int i = 0; i < edges; i++)
            {
                int[] line = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                int firstNode = line[0];
                int secondNode = line[1];

                graph.nodes[firstNode].Add(secondNode);
                graph.nodes[secondNode].Add(firstNode);
            }

            return graph;
        }
        private static void FindArticulationPointsDfs(Graph graph, int node, int depth)
        {
            visited[node] = true;
            depths[node] = depth;
            lowpoints[node] = depth;

            var children = 0;

            foreach (int child in graph.nodes[node])
            {
                if (!visited[child])
                {
                    stack.Push(node);
                    stack.Push(child);

                    parents[child] = node;
                    FindArticulationPointsDfs(graph, child, depth + 1);
                    children += 1;

                    if ((parents[node] == -1 && children > 1) ||                           //node is root 
                        (parents[node] != -1 && lowpoints[child] >= depth))                //node is not root
                    {
                        //articulationPoints.Add(node);
                        var component = new HashSet<int>();

                        while (true)
                        {
                            var stackChild = stack.Pop();
                            var stackNode = stack.Pop();

                            component.Add(stackChild);
                            component.Add(stackNode);

                            if (stackChild == child && stackNode == node)
                            {
                                break;
                            }
                        }

                        components.Add(component);
                    }

                    lowpoints[node] = Math.Min(lowpoints[node], lowpoints[child]);
                }
                else if (child != parents[node] &&
                    depths[child] < lowpoints[node])
                {
                    lowpoints[node] = depths[child];

                    stack.Push(node);
                    stack.Push(child);
                }
            }
        }
    }
}

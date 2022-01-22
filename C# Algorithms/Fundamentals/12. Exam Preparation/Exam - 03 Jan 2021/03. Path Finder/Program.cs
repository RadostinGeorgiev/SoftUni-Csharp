namespace _03._Path_Finder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static List<int>[] graph;
        public static bool[] visited;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            graph = new List<int>[nodes];

            for (int node = 0; node < nodes; node++)
            {

                var children = Console.ReadLine();

                if (children == string.Empty)
                {
                    graph[node] = new List<int>();
                }
                else
                {
                    graph[node] = children.Split().Select(int.Parse).ToList();
                }
            }

            int pathsNumber = int.Parse(Console.ReadLine());

            for (int path = 0; path < pathsNumber; path++)
            {
                var currentPath = Console.ReadLine().Split().Select(int.Parse).ToArray();

                bool isExist = false;

                visited = new bool[nodes];
                isExist = true;

                DFS(currentPath[0], currentPath, 0);

                foreach (var node in currentPath)
                {
                    if (!visited[node])
                    {
                        isExist = false;
                        break;
                    }
                }

                Console.WriteLine(isExist ? "yes" : "no");
            }
        }

        private static void DFS(int node, int[] path, int index)
        {
            if (visited[node] ||
                index == path.Length ||
                node != path[index])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child, path, index + 1);
            }
        }
    }
}
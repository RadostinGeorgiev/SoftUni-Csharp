namespace _03._Prims_Algorithm
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	internal class Edge : IComparable<Edge>
	{
		public int First { get; set; }
		public int Second { get; set; }
		public int Weight { get; set; }

		public override string ToString()
		{
			//return string.Format($"({this.First}-{this.Second}) -> {this.Weight}");
			return string.Format($"{First} - {Second}");
		}

		public int CompareTo(Edge other)
		{
			int result = Weight.CompareTo(other.Weight);
			return result;
		}
	}

	internal class Graph
	{
		public int EdgesCount { get; set; }
		public Dictionary<int, List<Edge>> Edges;

		public Graph(int edgesCount)
		{
			EdgesCount = edgesCount;
			this.Edges = new Dictionary<int, List<Edge>>();
		}
	}

	internal class Program
	{
		private static void Main(string[] args)
		{
			int number = int.Parse(Console.ReadLine());
			Graph graph = new Graph(number);
			graph = ReadGraphFromConsole(graph);

			//Prim's Algorithm  O(E + V.logV) -> for larger graphs; necessary specified start node
			List<Edge> MST = MSTPrim(graph);

			Console.WriteLine(string.Join(Environment.NewLine, MST));
		}

		private static Graph ReadGraphFromConsole(Graph graph)
		{
			for (int i = 0; i < graph.EdgesCount; i++)
			{
				int[] edgeData = Console.ReadLine()
										.Split(", ")
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
					Weight = edgeData[2]
				};

				graph.Edges[firstNode].Add(edge);
				graph.Edges[secondNode].Add(edge);
			}

			return graph;
		}

		private static List<Edge> MSTPrim(Graph graph)
		{
			List<Edge> spanningTree = new List<Edge>();
			HashSet<int> spanningTreeNodes = new HashSet<int>();

			foreach (int node in graph.Edges.Keys)
			{
				if (!spanningTreeNodes.Contains(node))
				{
					Prim(graph, node, spanningTree, spanningTreeNodes);
				}
			}

			return spanningTree;

			static void Prim(Graph graph,
				int startNode,
				List<Edge> spanningTree,
				HashSet<int> spanningTreeNodes)
			{
				List<Edge> priorityQueue = new List<Edge>();
				spanningTreeNodes.Add(startNode);                               //add startNode in spanningTree
				priorityQueue.AddRange(graph.Edges[startNode]);            //add startNode edge in queue
				priorityQueue.Sort();

				while (priorityQueue.Count != 0)
				{
					Edge minEdge = priorityQueue.First();							 //get edge with min weight from queue
					priorityQueue.Remove(minEdge);
					int nonTreeNode = -1;                                            //check if nodes of this edge are part of the tree

					if (spanningTreeNodes.Contains(minEdge.First)
						&& !spanningTreeNodes.Contains(minEdge.Second))
					{
						nonTreeNode = minEdge.Second;
					}

					if (spanningTreeNodes.Contains(minEdge.Second)
						&& !spanningTreeNodes.Contains(minEdge.First))
					{
						nonTreeNode = minEdge.First;
					}

					if (nonTreeNode != -1)                                           //if we have only one node as part of the tree:
					{
						spanningTree.Add(minEdge);                              //add edge in spanning tree 
						spanningTreeNodes.Add(nonTreeNode);                     //add this edge to the tree
						priorityQueue.AddRange(graph.Edges[nonTreeNode]);  //add edges of the nonTree node to the queue 
						priorityQueue.Sort();
					}
				}
			}
		}
	}
}
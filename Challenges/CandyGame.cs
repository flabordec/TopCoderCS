using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CandyGame
{
	class Node
	{
		public int Index { get; private set; }
		public int Depth { get; private set; }
		public Node Parent { get; private set; }

		public Node(int index, int depth, Node parent)
		{
			this.Index = index;
			this.Depth = depth;
			this.Parent = parent;
		}
	}

	public int maximumCandy(string[] graph, int target)
	{
		int[] powersOfTwo = new int[graph.Length];
		powersOfTwo[0] = 1;
		for (int i = 1; i < powersOfTwo.Length; i++) 
			powersOfTwo[i] = powersOfTwo[i-1] * 2;

		if (graph.Length == 1)
			return 0;

		bool[] seen = new bool[graph.Length];

		Dictionary<int, List<Node>> childNodes = new Dictionary<int, List<Node>>();
		for (int i = 0; i < graph.Length; i++)
			childNodes.Add(i, new List<Node>());

		Queue<Node> queue = new Queue<Node>();
		queue.Enqueue(new Node(target, 0, null));
		seen[target] = true;
		int maxDepth = 0;
		while (queue.Any())
		{
			Node curr = queue.Dequeue();

			bool anyChildren = false;
			for (int destIndex = 0; destIndex < graph[curr.Index].Length; destIndex++)
			{
				if (graph[curr.Index][destIndex] == 'Y' && !seen[destIndex])
				{
					seen[destIndex] = true;
					queue.Enqueue(new Node(destIndex, curr.Depth + 1, curr));
					anyChildren = true;
				}
			}
			if (!anyChildren)
			{
				childNodes[curr.Depth].Add(curr);
				maxDepth = curr.Depth;
			}
		}

		if (seen.Any(s => !s))
			return -1;

		long totalCandy = 0;
		bool[] seenCalc = new bool[graph.Length];
		seenCalc[target] = true;
		for (int childDepth = maxDepth; childDepth >= 0; childDepth--)
		{
			for (int i = 0; i < childNodes[childDepth].Count; i++)
			{
				Node node = childNodes[childDepth][i];
				int depth = 0;
				while (!seenCalc[node.Index])
				{
					seenCalc[node.Index] = true;
					node = node.Parent;
					depth++;
				}
				totalCandy += (powersOfTwo[depth] - 1);
				if (totalCandy > 2000000000)
					return -1;
			}
		}

		return (int)totalCandy;
	}
}

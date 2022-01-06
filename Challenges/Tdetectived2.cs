using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Failed...
/// </summary>
public class Tdetectived2
{
	class Node
	{
		public int Visited { get; set; }
		public int[] Suspicion { get; set; }
		public int Ix { get; set; }
		public int Time { get; set; }

		public Node(int visited, int[] suspicion, int ix, int time)
		{
			this.Visited = visited;
			this.Suspicion = suspicion;
			this.Ix = ix;
			this.Time = time;
		}
	}

	public int reveal(string[] s)
	{
		int[] times = new int[s.Length];
		Node initial = new Node(0, new int[s.Length], 0, 0);

		Queue<Node> queue = new Queue<Node>();
		queue.Enqueue(initial);

		HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();

		while (queue.Any())
		{
			Node curr = queue.Dequeue();

			if (visited.Contains(new Tuple<int, int>(curr.Ix, curr.Visited)))
				continue;
			visited.Add(new Tuple<int, int>(curr.Ix, curr.Visited));

			int nVisited = curr.Visited;
			nVisited |= 1 << curr.Ix;

			if (times[curr.Ix] == 0)
				times[curr.Ix] = curr.Time;

			HashSet<int> suspectedIndices = new HashSet<int>();
			int maxSuspicion = 0;
			int[] suspicion = new int[s.Length];
			for (int i = 0; i < s[curr.Ix].Length; i++)
			{
				if ((nVisited & (1 << i)) == (1 << i))
					continue;

				int vI = (int)s[curr.Ix][i] - '0';
				suspicion[i] = Math.Max(vI, curr.Suspicion[i]);
				if (suspicion[i] == maxSuspicion)
				{
					suspectedIndices.Add(i);
				}
				else if (suspicion[i] > maxSuspicion)
				{
					suspectedIndices.Clear();
					suspectedIndices.Add(i);
					maxSuspicion = suspicion[i];
				}
			}

			foreach (int ix in suspectedIndices)
			{
				queue.Enqueue(new Node(nVisited, suspicion, ix, curr.Time + 1));
			}
		}

		int result = 0;
		for (int i = 1; i < times.Length; i++)
			result += (i * times[i]);

		return result;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class LuckyCycle
{
	public int[] getEdge(int[] edge1, int[] edge2, int[] weight)
	{
		int[,] tree = new int[weight.Length + 1, weight.Length + 1];

		for (int i = 0; i < weight.Length; i++)
		{
			int a = edge1[i] - 1;
			int b = edge2[i] - 1;
			int w = weight[i];
			tree[a, b] = w;
			tree[b, a] = w;
		}

		Queue<Case> queue = new Queue<Case>();
		for (int startNode = 0; startNode < tree.GetLength(0); startNode++)
		{
			HashSet<int> seen = new HashSet<int>();
			queue.Enqueue(new Case(startNode, startNode, 0, 0));

			while (queue.Any())
			{
				Case curr = queue.Dequeue();
				seen.Add(curr.Node);

				Console.WriteLine("Visiting {0} with balance {1}",
							curr.Node + 1, curr.Balance);

				if (curr.Balance == 1 && curr.Length > 1)
					return new[] { curr.Start + 1, curr.Node + 1, 7 };
				else if (curr.Balance == -1 && curr.Length > 1)
					return new[] { curr.Start + 1, curr.Node + 1, 4 };

				for (int nextNode = 0; nextNode < tree.GetLength(0); nextNode++)
				{
					int w = tree[curr.Node, nextNode];
					if (w != 0 && !seen.Contains(nextNode))
					{
						int balance = curr.Balance;
						int nBalance = (w == 4) ? balance + 1 : balance - 1;
						Console.WriteLine("Going from {0} to {1} with balance {2}",
							curr.Node + 1, nextNode + 1, nBalance);

						Case next = new Case(curr.Start, nextNode, nBalance, curr.Length + 1);
						queue.Enqueue(next);
					}
				}
			}
		}
		return new int[0];
	}

	class Case
	{
		public int Start { get; set; }
		public int Node { get; set; }
		public int Balance { get; set; }
		public int Length { get; set; }

		public Case(int start, int node, int balance, int length)
		{
			this.Start = start;
			this.Node = node;
			this.Balance = balance;
			this.Length = length;
		}
	}
}

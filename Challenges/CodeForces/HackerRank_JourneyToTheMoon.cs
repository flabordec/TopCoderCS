using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

class Solution_JourneyToTheMoon
{
	public class DisjointSet
	{
		private int[] Parents { get; }
		private int[] Ranks { get; }

		private readonly Dictionary<int, int> mGroupCounts;
		public ReadOnlyDictionary<int, int> GroupCounts => 
			new ReadOnlyDictionary<int, int>(mGroupCounts);

		public DisjointSet(int n)
		{
			this.Parents = new int[n];
			this.Ranks = new int[n];
			this.mGroupCounts = new Dictionary<int, int>();
			for (int i = 0; i < n; i++)
				Add(i);
		}

		private void Add(int x)
		{
			this.Parents[x] = x;
			this.Ranks[x] = 0;
			this.mGroupCounts.Add(x, 1);
		}

		public bool AreConnected(int x, int y)
		{
			return Find(x) == Find(y);
		}

		private int Find(int x)
		{
			if (this.Parents[x] != x)
				this.Parents[x] = Find(this.Parents[x]);

			return this.Parents[x];
		}

		public void Union(int x, int y)
		{
			int xRoot = Find(x);
			int yRoot = Find(y);
			if (xRoot == yRoot)
				return;

			if (this.Ranks[xRoot] < this.Ranks[yRoot])
			{
				this.Parents[xRoot] = yRoot;

				this.mGroupCounts[yRoot] += this.mGroupCounts[xRoot];
				this.mGroupCounts.Remove(xRoot);
			}
			else if (this.Ranks[xRoot] > this.Ranks[yRoot])
			{
				this.Parents[yRoot] = xRoot;

				this.mGroupCounts[xRoot] += this.mGroupCounts[yRoot];
				this.mGroupCounts.Remove(yRoot);
			}
			else
			{
				this.Parents[yRoot] = xRoot;
				this.Ranks[xRoot]++;

				this.mGroupCounts[xRoot] += this.mGroupCounts[yRoot];
				this.mGroupCounts.Remove(yRoot);
			}
		}
	}

	static void Main(String[] args)
	{
		string[] lineSplit;

		lineSplit = Console.ReadLine().Split(' ');
		int N = Convert.ToInt32(lineSplit[0]);
		int P = Convert.ToInt32(lineSplit[1]);

		DisjointSet set = new DisjointSet(N);
		for (int i = 0; i < P; i++)
		{
			lineSplit = Console.ReadLine().Split(' ');
			int a = Convert.ToInt32(lineSplit[0]);
			int b = Convert.ToInt32(lineSplit[1]);
			set.Union(a, b);
		}

		int total = 0;
		foreach (int group in set.GroupCounts.Keys)
		{
			int countInGroup = set.GroupCounts[group];
			int remaining = N - countInGroup;
			Console.Error.WriteLine($"Group {group} has {countInGroup} members ({remaining} left)");
			
			total += countInGroup * remaining;
		}
		Console.WriteLine(total / 2);
	}
}
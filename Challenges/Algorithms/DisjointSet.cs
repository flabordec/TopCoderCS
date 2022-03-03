using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Challenges.Algorithms
{
	public class DisjointSet<T> : IEnumerable<T>
	{
		private Dictionary<T, T> Parents { get; }
		private Dictionary<T, int> Ranks { get; }


		public DisjointSet()
		{
			this.Parents = new Dictionary<T, T>();
			this.Ranks = new Dictionary<T, int>();
		}

		public void Add(T x)
		{
			this.Parents.Add(x, x);
			this.Ranks.Add(x, 0);
		}

		public bool AreConnected(T x, T y)
		{
			return Find(x).Equals(Find(y));
		}

		private T Find(T x)
		{
			if (!this.Parents[x].Equals(x))
				this.Parents[x] = Find(this.Parents[x]);
			return this.Parents[x];
		}

		public void Union(T x, T y)
		{
			T xRoot = Find(x);
			T yRoot = Find(y);
			if (xRoot.Equals(yRoot))
				return;

			if (this.Ranks[xRoot].CompareTo(this.Ranks[yRoot]) < 0)
			{
				this.Parents[xRoot] = yRoot;
			}
			else if (this.Ranks[xRoot].CompareTo(this.Ranks[yRoot]) > 0)
			{
				this.Parents[yRoot] = xRoot;
			}
			else
			{
				this.Parents[yRoot] = xRoot;
				this.Ranks[xRoot]++;
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			return this.Parents.Keys.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

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
}

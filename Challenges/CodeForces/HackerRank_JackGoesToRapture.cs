using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
	class PriorityQueue<T>
	{
		#region Fields
		struct Interval
		{
			internal T First;
			internal T Last; 
			
			public override string ToString() { return String.Format("[{0}; {1}]", First, Last); }
		}

		IComparer<T> mComparer;
		IEqualityComparer<T> mItemEqualityComparer;

		Interval[] mHeap;

		int mSize;
		#endregion

		#region Util
		bool HeapifyMin(int i)
		{
			bool swappedroot = false;
			int cell = i, currentmin = cell;
			T currentitem = mHeap[cell].First;

			// bug20080222.txt
			{
				T other = mHeap[cell].Last;
				if (2 * cell + 1 < mSize && mComparer.Compare(currentitem, other) > 0)
				{
					swappedroot = true;
					UpdateLast(cell, currentitem);
					currentitem = other;
				}
			}

			T minitem = currentitem;

			while (true)
			{
				int l = 2 * cell + 1, r = l + 1;
				T lv, rv;

				if (2 * l < mSize && mComparer.Compare(lv = mHeap[l].First, minitem) < 0)
				{ currentmin = l; minitem = lv; }

				if (2 * r < mSize && mComparer.Compare(rv = mHeap[r].First, minitem) < 0)
				{ currentmin = r; minitem = rv; }

				if (currentmin == cell)
					break;

				UpdateFirst(cell, minitem);
				cell = currentmin;

				//Maybe swap first and last
				T other = mHeap[cell].Last;
				if (2 * currentmin + 1 < mSize && mComparer.Compare(currentitem, other) > 0)
				{
					UpdateLast(cell, currentitem);
					currentitem = other;
				}


				minitem = currentitem;
			}

			if (cell != i || swappedroot)
				UpdateFirst(cell, minitem);
			return swappedroot;
		}

		bool HeapifyMax(int i)
		{
			bool swappedroot = false;
			int cell = i, currentmax = cell;
			T currentitem = mHeap[cell].Last;

			// bug20080222.txt
			{
				T other = mHeap[cell].First;
				if (2 * cell + 1 < mSize && mComparer.Compare(currentitem, other) < 0)
				{
					swappedroot = true;
					UpdateFirst(cell, currentitem);
					currentitem = other;
				}
			}

			T maxitem = currentitem;

			while (true)
			{
				int l = 2 * cell + 1, r = l + 1;
				T lv, rv;

				if (2 * l + 1 < mSize && mComparer.Compare(lv = mHeap[l].Last, maxitem) > 0)
				{ currentmax = l; maxitem = lv; }

				if (2 * r + 1 < mSize && mComparer.Compare(rv = mHeap[r].Last, maxitem) > 0)
				{ currentmax = r; maxitem = rv; }

				if (currentmax == cell)
					break;

				UpdateLast(cell, maxitem);
				cell = currentmax;

				//Maybe swap first and last
				T other = mHeap[cell].First;
				if (mComparer.Compare(currentitem, other) < 0)
				{
					UpdateFirst(cell, currentitem);
					currentitem = other;
				}

				maxitem = currentitem;
			}

			if (cell != i || swappedroot) //Check could be better?
				UpdateLast(cell, maxitem);
			return swappedroot;
		}

		void BubbleUpMin(int i)
		{
			if (i > 0)
			{
				T min = mHeap[i].First, iv = min;
				int p = (i + 1) / 2 - 1;

				while (i > 0)
				{
					if (mComparer.Compare(iv, min = mHeap[p = (i + 1) / 2 - 1].First) < 0)
					{
						UpdateFirst(i, min);
						min = iv;
						i = p;
					}
					else
						break;
				}

				UpdateFirst(i, iv);
			}
		}

		void BubbleUpMax(int i)
		{
			if (i > 0)
			{
				T max = mHeap[i].Last, iv = max;
				int p = (i + 1) / 2 - 1;

				while (i > 0)
				{
					if (mComparer.Compare(iv, max = mHeap[p = (i + 1) / 2 - 1].Last) > 0)
					{
						UpdateLast(i, max);
						max = iv;
						i = p;
					}
					else
						break;
				}

				UpdateLast(i, iv);

			}
		}

		#endregion

		#region Constructors
		
		public PriorityQueue() : this(16, Comparer<T>.Default, EqualityComparer<T>.Default) { }

		private PriorityQueue(int capacity, IComparer<T> comparer, IEqualityComparer<T> itemequalityComparer)
		{
			this.mComparer = comparer;
			this.mItemEqualityComparer = itemequalityComparer;
			int length = 1;
			while (length < capacity) length <<= 1;
			mHeap = new Interval[length];
		}

		#endregion

		#region IPriorityQueue<T> Members

		public T FindMin()
		{
			if (mSize == 0)
				throw new IndexOutOfRangeException();

			return mHeap[0].First;
		}

		public T FindMax()
		{
			if (mSize == 0)
				throw new IndexOutOfRangeException("Heap is empty");
			else if (mSize == 1)
				return mHeap[0].First;
			else
				return mHeap[0].Last;
		}

		public T DeleteMin()
		{
			if (mSize == 0)
				throw new IndexOutOfRangeException();

			T retval = mHeap[0].First;
			if (mSize == 1)
			{
				mSize = 0;
				mHeap[0].First = default(T);
			}
			else
			{
				int lastcell = (mSize - 1) / 2;

				if (mSize % 2 == 0)
				{
					UpdateFirst(0, mHeap[lastcell].Last);
					mHeap[lastcell].Last = default(T);
				}
				else
				{
					UpdateFirst(0, mHeap[lastcell].First);
					mHeap[lastcell].First = default(T);
				}

				mSize--;
				HeapifyMin(0);
			}

			return retval;

		}

		public T DeleteMax()
		{
			if (mSize == 0)
				throw new IndexOutOfRangeException();

			T retval;

			if (mSize == 1)
			{
				mSize = 0;
				retval = mHeap[0].First;
				mHeap[0].First = default(T);
			}
			else
			{
				retval = mHeap[0].Last;

				int lastcell = (mSize - 1) / 2;

				if (mSize % 2 == 0)
				{
					UpdateLast(0, mHeap[lastcell].Last);
					mHeap[lastcell].Last = default(T);
				}
				else
				{
					UpdateLast(0, mHeap[lastcell].First);
					mHeap[lastcell].First = default(T);
				}

				mSize--;
				HeapifyMax(0);
			}

			return retval;
		}

		#endregion

		#region IExtensible<T> Members

		public bool Add(T item)
		{
			if (mSize == 0)
			{
				mSize = 1;
				UpdateFirst(0, item);
				return true;
			}

			if (mSize == 2 * mHeap.Length)
			{
				Interval[] newheap = new Interval[2 * mHeap.Length];

				Array.Copy(mHeap, newheap, mHeap.Length);
				mHeap = newheap;
			}

			if (mSize % 2 == 0)
			{
				int i = mSize / 2, p = (i + 1) / 2 - 1;
				T tmp = mHeap[p].Last;

				if (mComparer.Compare(item, tmp) > 0)
				{
					UpdateFirst(i, tmp);
					UpdateLast(p, item);
					BubbleUpMax(p);
				}
				else
				{
					UpdateFirst(i, item);

					if (mComparer.Compare(item, mHeap[p].First) < 0)
						BubbleUpMin(i);
				}
			}
			else
			{
				int i = mSize / 2;
				T other = mHeap[i].First;

				if (mComparer.Compare(item, other) < 0)
				{
					UpdateLast(i, other);
					UpdateFirst(i, item);
					BubbleUpMin(i);
				}
				else
				{
					UpdateLast(i, item);
					BubbleUpMax(i);
				}
			}
			mSize++;

			return true;
		}

		private void UpdateLast(int cell, T item)
		{
			mHeap[cell].Last = item;
		}

		private void UpdateFirst(int cell, T item)
		{
			mHeap[cell].First = item;
		}

		public void AddAll<U>(IEnumerable<U> items) where U : T
		{
			int oldsize = mSize;
			foreach (T item in items)
				Add(item);
		}

		#endregion

		#region ICollection<T> members

		public bool IsEmpty { get { return mSize == 0; } }

		public int Count { get { return mSize; } }
		
		#endregion
	}

	class Node : IComparable<Node>
	{
		public int Ix { get; }
		public int MaxCost { get; }

		public Node(int ix, int maxCost)
		{
			this.Ix = ix;
			this.MaxCost = maxCost;
		}

		/// <inheritdoc />
		public int CompareTo(Node other)
		{
			return this.MaxCost.CompareTo(other.MaxCost);
		}
	} 

	static void Main(String[] args)
	{
		string line;
		string[] lineSplit;

		line = Console.ReadLine();
		lineSplit = line.Split(' ');
		int n = int.Parse(lineSplit[0]);
		int e = int.Parse(lineSplit[1]);

		Dictionary<int, Dictionary<int, int>> graph = new Dictionary<int, Dictionary<int, int>>();
		for (int i = 0; i < n; i++)
			graph.Add(i, new Dictionary<int, int>());

		for (int i = 0; i < e; i++)
		{
			line = Console.ReadLine();
			lineSplit = line.Split(' ');

			int from = int.Parse(lineSplit[0]) - 1;
			int to = int.Parse(lineSplit[1]) - 1;
			int cost = int.Parse(lineSplit[2]);

			graph[from].Add(to, cost);
			graph[to].Add(from, cost);
		}

		PriorityQueue<Node> queue = new PriorityQueue<Node>();
		HashSet<int> seen = new HashSet<int>();
		seen.Add(0);
		queue.Add(new Node(0, 0));
		while (!queue.IsEmpty)
		{
			Node curr = queue.DeleteMin();
			seen.Add(curr.Ix);
			Console.Error.WriteLine($"Visiting {curr.Ix} with cost {curr.MaxCost}");

			if (curr.Ix == n - 1)
			{
				Console.WriteLine(curr.MaxCost);
				return;
			}

			foreach (int i in graph[curr.Ix].Keys)
			{
				if (seen.Contains(i))
					continue;
				
				int cost = graph[curr.Ix][i];
				int maxCost = Math.Max(curr.MaxCost, cost);
				queue.Add(new Node(i, maxCost));
			}
		}
		Console.WriteLine("NO PATH EXISTS");
	}
}
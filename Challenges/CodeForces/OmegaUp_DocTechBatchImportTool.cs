using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class OmegaUp_DocTechBatchImportTool
{
	class PriorityQueue<T>
	{
		#region Fields
		struct Interval
		{
			internal T First;
			internal T Last;

			public override string ToString() { return $"[{First}; {Last}]"; }
		}

		readonly IComparer<T> mComparer;

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

		public PriorityQueue() : this(16, Comparer<T>.Default) { }

		private PriorityQueue(int capacity, IComparer<T> comparer)
		{
			this.mComparer = comparer;
			int length = 1;
			while (length < capacity)
				length <<= 1;
			mHeap = new Interval[length];
		}

		#endregion

		#region IPriorityQueue<T> Members

		public T DequeueMin()
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

		#endregion

		#region IExtensible<T> Members

		public bool Enqueue(T item)
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
		
		#endregion

		#region ICollection<T> members

		public bool IsEmpty { get { return mSize == 0; } }

		#endregion
	}

	static void Main(string[] args)
	{
		int n = int.Parse(Console.ReadLine());
		int l = int.Parse(Console.ReadLine());

		bool[][] graph = new bool[n][];
		for (int i = 0; i < n; i++)
			graph[i] = new bool[n];

		for (int i = 0; i < l; i++)
		{
			string line = Console.ReadLine();
			string[] splitLine = line.Split(' ');
			int from = int.Parse(splitLine[0]);
			int to = int.Parse(splitLine[1]);

			graph[to][from] = true;
		}

		IEnumerable<int> topoSortedNodes = SortGraph(graph);
		Console.WriteLine(string.Join(" ", topoSortedNodes));
	}

	public static IEnumerable<int> SortGraph(bool[][] graph)
	{
		int[] edges = new int[graph.Length];

		var topoSortedNodes = new List<int>();
		var nodesWithNoEdges = new PriorityQueue<int>();
		for (int i = 0; i < graph.Length; i++)
		{
			for (int j = 0; j < graph.Length; j++)
			{
				if (graph[j][i])
					edges[i]++;
			}
			if (edges[i] == 0)
				nodesWithNoEdges.Enqueue(i);
		}

		while (!nodesWithNoEdges.IsEmpty)
		{
			int curr = nodesWithNoEdges.DequeueMin();
			topoSortedNodes.Add(curr);

			for (int i = 0; i < graph.Length; i++)
			{
				if (graph[curr][i])
				{
					edges[i]--;

					if (edges[i] == 0)
						nodesWithNoEdges.Enqueue(i);
				}
			}
		}

		if (topoSortedNodes.Count != graph.Length)
			// graph has cycles
			return null;
		else
			return topoSortedNodes;
	}
}
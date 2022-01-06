using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Solution_SynchronousShopping
{
	public class PriorityQueue<T>
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
			while (length < capacity)
				length <<= 1;
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

		public void AddAll<U>(IEnumerable<U> items) where U : T
		{
			int oldsize = mSize;
			foreach (T item in items)
				Enqueue(item);
		}

		#endregion

		#region ICollection<T> members

		public bool IsEmpty { get { return mSize == 0; } }

		public int Count { get { return mSize; } }

		#endregion
	}

	public class City
	{
		public int Fish { get; }

		public City(string line)
		{
			IEnumerable<int> fishInts = line.Split(' ').Skip(1).Select(s => int.Parse(s));
			this.Fish = ToFish(fishInts);
		}

		private int ToFish(IEnumerable<int> enumerable)
		{
			int fish = 0;
			foreach (int i in enumerable)
				fish |= (1 << (i - 1));
			return fish;
		}

		public void Visit(ref int i)
		{
			i |= this.Fish;
		}
	}

	public class State : IEquatable<State>, IComparable<State>
	{
		public int Cat1 { get; }
		public int Cat2 { get; }
		public int Time { get; }
		public int Fish { get; }

		public State(int cat1, int cat2, int time, int fish)
		{
			this.Cat1 = Math.Min(cat1, cat2);
			this.Cat2 = Math.Max(cat1, cat2);
			this.Time = time;
			this.Fish = fish;
		}

		public bool Equals(State other)
		{
			if (this.Cat1 != other.Cat1)
				return false;
			if (this.Cat2 != other.Cat2)
				return false;
			if (this.Time != other.Time)
				return false;
			if (this.Fish != other.Fish)
				return false;

			return true;
		}

		// override object.Equals
		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
				return false;
			return this.Equals(obj as State);
		}

		// override object.GetHashCode
		public override int GetHashCode()
		{
			unchecked // Overflow is fine, just wrap
			{
				int hash = 17;
				// Suitable nullity checks etc, of course :)
				hash = hash * 23 + this.Cat1.GetHashCode();
				hash = hash * 23 + this.Cat2.GetHashCode();
				hash = hash * 23 + this.Time.GetHashCode();
				hash = hash * 23 + this.Fish.GetHashCode();
				return hash;
			}

		}

		public int CompareTo(State other)
		{
			if (this.Time != other.Time)
				return this.Time.CompareTo(other.Time);
			if (this.Fish != other.Fish)
			{
				int nFish1 = NumberOfSetBits(this.Fish);
				int nFish2 = NumberOfSetBits(other.Fish);
				return nFish2.CompareTo(nFish1);
			}

			return 0;
		}

		int NumberOfSetBits(int i)
		{
			// Java: use >>> instead of >>
			// C or C++: use uint32_t
			i = i - ((i >> 1) & 0x55555555);
			i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
			return (((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
		}

	}

	static void Main(String[] args)
	{
		string[] split;
		split = Console.ReadLine().Split(' ');
		int n = Convert.ToInt32(split[0]);
		int m = Convert.ToInt32(split[1]);
		int k = Convert.ToInt32(split[2]);

		City[] cities = new City[n];
		for (int i = 0; i < n; i++)
		{
			cities[i] = new City(Console.ReadLine());
		}

		int[,] graph = new int[n, n];
		for (int i = 0; i < n; i++)
			for (int j = 0; j < n; j++)
				graph[i, j] = -1;

		for (int i = 0; i < m; i++)
		{
			split = Console.ReadLine().Split(' ');
			int from = Convert.ToInt32(split[0]) - 1;
			int to = Convert.ToInt32(split[1]) - 1;
			int cost = Convert.ToInt32(split[2]);
			graph[from, to] = cost;
			graph[to, from] = cost;
		}
		graph[n - 1, n - 1] = 0;

		int allFish = (1 << k) - 1;

		PriorityQueue<State> queue = new PriorityQueue<State>();
		HashSet<State> seen = new HashSet<State>();
		queue.Enqueue(new State(0, 0, 0, cities[0].Fish));
		while (!queue.IsEmpty)
		{
			State curr = queue.DequeueMin();
			if (curr.Cat1 == n - 1 && curr.Cat2 == n - 1 && curr.Fish == allFish)
			{
				Console.WriteLine(curr.Time);
				return;
			}

			for (int i = 0; i < n; i++)
			{
				if (graph[curr.Cat1, i] != -1)
				{
					for (int j = 0; j < n; j++)
					{
						if (graph[curr.Cat2, j] != -1)
						{
							int time = curr.Time;
							int nextTime = Math.Max(
								graph[curr.Cat1, i],
								graph[curr.Cat2, j]);
							time += nextTime;

							int fish = curr.Fish;
							cities[i].Visit(ref fish);
							cities[j].Visit(ref fish);

							State next = new State(i, j, time, fish);
							if (!seen.Contains(next))
							{
								queue.Enqueue(next);
								seen.Add(next);
							}
						}
					}
				}
			}
		}
	}
}

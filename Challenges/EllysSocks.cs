using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EllysSocks
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

	class State : IComparable<State>, IEquatable<State>
	{
		public int NumPairs { get; set; }
		public int MaxDifference { get; set; }
		public int Index { get; set; }

		public State(int numPairs, int maxDifference, int index)
		{
			this.NumPairs = numPairs;
			this.MaxDifference = maxDifference;
			this.Index = index;
		}

		public int CompareTo(State other)
		{
			return this.MaxDifference.CompareTo(other.MaxDifference);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as State);
		}

		public bool Equals(State other)
		{
			return 
				this.Index == other.Index &&
				this.MaxDifference == other.MaxDifference &&
				this.NumPairs == other.NumPairs;
		}

		public override int GetHashCode()
		{
			return this.Index ^ this.MaxDifference ^ this.NumPairs;
		}
	}

	public int getDifference(int[] S, int P)
	{
		Array.Sort(S);
		
		int minMaxDifference = int.MaxValue;

		var queue = new PriorityQueue<State>();
		var seen = new HashSet<State>();
		for (int i = 0; i < S.Length - 1; i++)
		{
			var state = new State(0, 0, i);
			seen.Add(state);
			queue.Add(state);
		}

		State curr;
		State nextState;
		while (!queue.IsEmpty)
		{
			curr = queue.DeleteMin();

			// Console.WriteLine("{0} {1} {2}", curr.NumPairs, curr.MaxDifference, curr.Index);

			if (curr.NumPairs == P)
				return curr.MaxDifference;

			if (curr.Index + 1 >= S.Length)
				continue;

			// Take these two socks
			int difference = Math.Abs(S[curr.Index] - S[curr.Index + 1]);
			int maxDifference = Math.Max(difference, curr.MaxDifference);
			nextState = new State(curr.NumPairs + 1, maxDifference, curr.Index + 2);
			if (!seen.Contains(nextState))
			{
				seen.Add(nextState);
				queue.Add(nextState);
			}

			// Do not take socks
			for (int i = curr.Index + 1; i < S.Length - 1; i++)
			{
				nextState = new State(curr.NumPairs, curr.MaxDifference, i);
				if (!seen.Contains(nextState))
				{
					seen.Add(nextState);
					queue.Add(nextState);
				}
			}
		}

		return minMaxDifference;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCS.Algorithms
{
    public class PriorityQueue<T>
    {
        #region Fields
        struct Interval
        {
            internal T First;
            internal T Last;

            public override string ToString() { return string.Format("[{0}; {1}]", First, Last); }
        }

        IComparer<T> _comparer;
        IEqualityComparer<T> _itemEqualityComparer;

        Interval[] mHeap;

        int _size;
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
                if (2 * cell + 1 < _size && _comparer.Compare(currentitem, other) > 0)
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

                if (2 * l < _size && _comparer.Compare(lv = mHeap[l].First, minitem) < 0)
                { currentmin = l; minitem = lv; }

                if (2 * r < _size && _comparer.Compare(rv = mHeap[r].First, minitem) < 0)
                { currentmin = r; minitem = rv; }

                if (currentmin == cell)
                    break;

                UpdateFirst(cell, minitem);
                cell = currentmin;

                //Maybe swap first and last
                T other = mHeap[cell].Last;
                if (2 * currentmin + 1 < _size && _comparer.Compare(currentitem, other) > 0)
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
                if (2 * cell + 1 < _size && _comparer.Compare(currentitem, other) < 0)
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

                if (2 * l + 1 < _size && _comparer.Compare(lv = mHeap[l].Last, maxitem) > 0)
                { currentmax = l; maxitem = lv; }

                if (2 * r + 1 < _size && _comparer.Compare(rv = mHeap[r].Last, maxitem) > 0)
                { currentmax = r; maxitem = rv; }

                if (currentmax == cell)
                    break;

                UpdateLast(cell, maxitem);
                cell = currentmax;

                //Maybe swap first and last
                T other = mHeap[cell].First;
                if (_comparer.Compare(currentitem, other) < 0)
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
                    if (_comparer.Compare(iv, min = mHeap[p = (i + 1) / 2 - 1].First) < 0)
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
                    if (_comparer.Compare(iv, max = mHeap[p = (i + 1) / 2 - 1].Last) > 0)
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
            this._comparer = comparer;
            this._itemEqualityComparer = itemequalityComparer;
            int length = 1;
            while (length < capacity) length <<= 1;
            mHeap = new Interval[length];
        }

        #endregion

        #region IPriorityQueue<T> Members

        public T FindMin()
        {
            if (_size == 0)
                throw new IndexOutOfRangeException();

            return mHeap[0].First;
        }

        public T FindMax()
        {
            if (_size == 0)
                throw new IndexOutOfRangeException("Heap is empty");
            else if (_size == 1)
                return mHeap[0].First;
            else
                return mHeap[0].Last;
        }

        public T DequeueMin()
        {
            if (_size == 0)
                throw new IndexOutOfRangeException();

            T retval = mHeap[0].First;
            if (_size == 1)
            {
                _size = 0;
                mHeap[0].First = default(T);
            }
            else
            {
                int lastcell = (_size - 1) / 2;

                if (_size % 2 == 0)
                {
                    UpdateFirst(0, mHeap[lastcell].Last);
                    mHeap[lastcell].Last = default(T);
                }
                else
                {
                    UpdateFirst(0, mHeap[lastcell].First);
                    mHeap[lastcell].First = default(T);
                }

                _size--;
                HeapifyMin(0);
            }

            return retval;

        }

        public T DeleteMax()
        {
            if (_size == 0)
                throw new IndexOutOfRangeException();

            T retval;

            if (_size == 1)
            {
                _size = 0;
                retval = mHeap[0].First;
                mHeap[0].First = default(T);
            }
            else
            {
                retval = mHeap[0].Last;

                int lastcell = (_size - 1) / 2;

                if (_size % 2 == 0)
                {
                    UpdateLast(0, mHeap[lastcell].Last);
                    mHeap[lastcell].Last = default(T);
                }
                else
                {
                    UpdateLast(0, mHeap[lastcell].First);
                    mHeap[lastcell].First = default(T);
                }

                _size--;
                HeapifyMax(0);
            }

            return retval;
        }

        #endregion

        #region IExtensible<T> Members

        public bool Enqueue(T item)
        {
            if (_size == 0)
            {
                _size = 1;
                UpdateFirst(0, item);
                return true;
            }

            if (_size == 2 * mHeap.Length)
            {
                Interval[] newheap = new Interval[2 * mHeap.Length];

                Array.Copy(mHeap, newheap, mHeap.Length);
                mHeap = newheap;
            }

            if (_size % 2 == 0)
            {
                int i = _size / 2, p = (i + 1) / 2 - 1;
                T tmp = mHeap[p].Last;

                if (_comparer.Compare(item, tmp) > 0)
                {
                    UpdateFirst(i, tmp);
                    UpdateLast(p, item);
                    BubbleUpMax(p);
                }
                else
                {
                    UpdateFirst(i, item);

                    if (_comparer.Compare(item, mHeap[p].First) < 0)
                        BubbleUpMin(i);
                }
            }
            else
            {
                int i = _size / 2;
                T other = mHeap[i].First;

                if (_comparer.Compare(item, other) < 0)
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
            _size++;

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
            int oldsize = _size;
            foreach (T item in items)
                Enqueue(item);
        }

        #endregion

        #region ICollection<T> members

        public bool IsEmpty { get { return _size == 0; } }

        public int Count { get { return _size; } }

        #endregion
    }
}

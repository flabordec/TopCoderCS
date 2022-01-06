using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UnionOfSetIntervals
{
	class Interval
	{

		private readonly int mLowerBound;
		public int LowerBound { get { return mLowerBound; } }

		private readonly int mUpperBound;
		public int UpperBound { get { return mUpperBound; } }

		public Interval(int lowerBound, int upperBound)
		{
			this.mLowerBound = lowerBound;
			this.mUpperBound = upperBound;
		}

		public override string ToString()
		{
			return string.Format("({0}, {1})", LowerBound, UpperBound);
		}
	}

	public int nthElement(int[] lowerBound, int[] upperBound, int n)
	{
		List<Interval> intervals = new List<Interval>();
		for (int i = 0; i < lowerBound.Length; i++)
		{
			intervals.Add(new Interval(lowerBound[i], upperBound[i]));
		}

		intervals = (
			from interval in intervals
			orderby interval.LowerBound
			select interval
			).ToList();

		int cn = int.MinValue;
		int intervalIndex = 0;
		int intervalCount = 0;
		int nIndex = 0;
		while (nIndex < n + 1)
		{
			Interval interval = intervals[intervalIndex];
			Console.WriteLine("{0}\t{1}\t{2}", cn, interval, nIndex);

			if (cn < interval.LowerBound)
				intervalCount = interval.UpperBound - interval.LowerBound + 1;
			else if (cn >= interval.LowerBound)
				intervalCount = interval.UpperBound - cn;

			if (nIndex + intervalCount >= n + 1)
			{
				int needed = n + 1 - nIndex;
				return cn + needed;
			}

			if (intervalCount > 0)
				nIndex += intervalCount;
			cn = Math.Max(interval.UpperBound, cn);

			intervalIndex++;
		}
		return 0;
	}
}

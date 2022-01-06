using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OlympicCandles
{
	class ReverseComparer : IComparer<int>
	{
		public int Compare(int x, int y)
		{
			return y.CompareTo(x);
		}
	}

	public int numberOfNights(int[] candles)
	{
		for (int i = 1; i <= 50; i++)
		{
			Array.Sort(candles, new ReverseComparer());
			Console.WriteLine(string.Join(", ", candles));
			for (int j = 0; j < i; j++)
			{
				if (j < candles.Length && candles[j] > 0)
					candles[j]--;
				else
					return i - 1;
			}
		}
		return 50;
	}
}

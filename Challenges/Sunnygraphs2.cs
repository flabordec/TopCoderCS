using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Sunnygraphs2
{
	const int max = 52;
	bool[] v = new bool[max];
	
	public long count(int[] a)
	{
		long ans = 1L << a.Length;

		for (int i = 0; i < a.Length; i++)
		{
			int t = GetCycleLength(i, a);
			if (t != 0)
			{
				ans /= 1L << t;
				ans *= (1L << t) - 1;
			}
		}

		if (AllReachCycleEnd(a))
			ans++;

		return ans;
	}

	private int GetCycleLength(int x, int[] a)
	{
		int y = x;
		for (int i = 1; i <= a.Length; i++)
		{
			y = a[y];
			if (y < x)
				break;
			if (y == x)
				return i;
		}
		return 0;
	}

	private bool AllReachCycleEnd(int[] a)
	{
		int cycleEnd = 0;
		for (int i = 0; i < a.Length; i++)
			cycleEnd = a[cycleEnd];

		for (int i = 0; i < a.Length; i++)
		{
			int x = i;
			bool reachedCycleEnd = false;
			for (int j = 0; j < a.Length; j++)
			{
				x = a[x];
				if (x == cycleEnd)
				{
					reachedCycleEnd = true;
					break;
				}
			}
			if (!reachedCycleEnd)
				return false;
		}
		return true;
	}
	
}

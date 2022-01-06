using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ThueMorseGame
{
	public string get(int n, int m)
	{
		long full = (1L << m) - 1;
		long mask = full;

		for (int i = 0; i <= n; i++)
		{
			if (!IsChoosable(i) || mask != full)
				mask = ((mask << 1) | 1) & full;
			else
				mask = (mask << 1) & full;
		}
		return (mask & 1) != 0 ? "Alice" : "Bob";
	}

	public string getArray(int n, int m)
	{
		bool[] dp = new bool[n + 1];
		bool[] choosable = new bool[n + 1];

		for (int i = 1; i <= m; i++)
		{
			dp[i] = true;
			choosable[i] = IsChoosable(i);
		}

		for (int i = m + 1; i <= n; i++)
		{
			choosable[i] = IsChoosable(i);

			for (int j = 1; j <= m; j++)
			{
				int ni = i - j;
				if (choosable[ni] && !dp[ni])
					dp[i] = true;
			}
			
		}

		Console.WriteLine(string.Join("\n", dp.Select(t => t ? "1" : "0")));
		return dp[n] ? "Alice" : "Bob";
	}

	private bool IsChoosable(int i)
	{
		return (NumberOfSetBits(i) & 1) == 0;
	}

	private int NumberOfSetBits(int i)
	{
		unchecked
		{
			i = i - ((i >> 1) & 0x55555555);
			i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
			return (((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
		}
	}
}
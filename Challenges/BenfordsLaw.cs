using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BenfordsLaw
{
	public int questionableDigit(int[] transactions, int threshold)
	{
		int[] digitCounts = new int[10];
		foreach (int transaction in transactions)
		{
			int t = transaction;
			while (t >= 10)
				t /= 10;
			digitCounts[t]++;
		}

		for (int i = 1; i < 10; i++)
		{
			double benford = Math.Log10(1 + 1.0 / i) * transactions.Length;

			double max = benford * threshold;
			double min = benford / threshold;

			if (digitCounts[i] < min || digitCounts[i] > max)
			{
				Console.WriteLine("{0} => {1} in range [{2}, {3}]", i, digitCounts[i], min, max);
				return i;
			}
		}
		return -1;
	}
}

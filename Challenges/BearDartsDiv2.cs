using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class BearDartsDiv2
{
	public long count(int[] w)
	{
		var set = new HashSet<long>();
		int[] tw = new int[1000000 + 1];
		int mx = 1000000;
		int[] tr = new int[1000000 + 1];
		long r = 0;

		for (int i = 0; i < w.Length; i++)
		{
			r += tr[w[i]];

			foreach (long k in set)
			{
				long prod = k * w[i];
				if (prod <= mx)
					tr[(int)prod] += tw[(int)k];
			}

			for (int j = i - 1; -1 < j; j--)
			{
				if ((long)w[i] * w[j] > mx) 
					continue;

				tw[w[i] * w[j]]++;
				set.Add(w[i] * w[j]);
			}
		}

		return r;
	}
}

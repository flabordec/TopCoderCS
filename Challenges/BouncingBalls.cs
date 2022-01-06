using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BouncingBalls
{
	public double expectedBounces(int[] x, int T)
	{
		double expected = 0.0;
		Array.Sort(x);
		for (int i = 0; i < x.Length; i++)
		{
			for (int j = i + 1; j < x.Length; j++)
			{
				if (x[j] - x[i] <= T + T)
					expected += 0.25;
			}
		}

		return expected;
	}
}
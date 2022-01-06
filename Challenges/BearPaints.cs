using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BearPaints
{
	public long maxArea(int W, int H, long M)
	{
		long best = 0;

		for (long h = H; h > 0; h--)
		{
			long w = M / h;
			if (w > W)
				w = W;

			if (best < w * h)
				best = w * h;
		}

		return best;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CountGame
{
	public int howMany(int maxAdd, int goal, int next)
	{
		int offset = goal % (maxAdd + 1);

		for (int i = 0; i < maxAdd; i++)
		{
			int remainder = (next + i - offset) % (maxAdd + 1);
			if (remainder == 0)
				return i + 1;
		}
		return -1;
	}
}

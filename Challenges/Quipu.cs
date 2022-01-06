using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Quipu
{
	public int readKnots(string knots)
	{
		int ret = 0;
		for (int i = 1; i < knots.Length - 1; i++)
		{
			if (knots[i] == 'X')
				ret++;
			else if (knots[i] == '-')
				ret *= 10;
		}
		return ret;
	}
}

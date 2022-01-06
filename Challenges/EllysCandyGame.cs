using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EllysCandyGame
{
	public string getWinner(int[] sweets)
	{
		int optimalScore = MinMax(sweets, 0, 0, true);
		if (optimalScore == 0)
			return "Draw";
		else if (optimalScore < 0)
			return "Elly";
		else
			return "Kris";
	}

	public int MinMax(int[] sweets, int s1, int s2, bool p1)
	{
		if (!sweets.Any(i => i > 0))
			return s1 - s2;

		int best = 0;
		for (int i = 0; i < sweets.Length; i++)
		{
			if (sweets[i] != 0)
			{
				int oldi = 0;
				int oldni = 0;
				int oldpi = 0;

				oldi = sweets[i];
				sweets[i] = 0;

				if (i + 1 < sweets.Length)
				{
					oldni = sweets[i + 1];
					sweets[i + 1] *= 2;
				}

				if (i - 1 >= 0)
				{
					oldpi = sweets[i - 1];
					sweets[i - 1] *= 2;
				}
				if (p1)
					s1 += oldi;
				else
					s2 += oldi;

				int result = MinMax(sweets, s1, s2, !p1);
				if (p1 && result > best)
					best = result;
				else if (!p1 && result < best)
					best = result;

				if (p1)
					s1 -= oldi;
				else
					s2 -= oldi;
				
				sweets[i] = oldi;
				if (i + 1 < sweets.Length) 
					sweets[i + 1] = oldni;

				if (i - 1 >= 0)
					sweets[i - 1] = oldpi;
			}
		}
		return best;
	}
}


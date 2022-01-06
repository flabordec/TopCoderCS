using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SilverDistance
{
	public int minSteps(int sx, int sy, int gx, int gy)
	{
		// Ooch closer until you are at most 2 steps away on x and 2 steps away on y
		int isteps = 0;
		while (sx < gx && sy < gy)
		{
			sx++;
			sy++;
			isteps++;
		}
		while (sx > gx && sy > gy)
		{
			sx--;
			sy--;
			isteps++;
		}
		while (sx < gx && sy > gy)
		{
			sx++;
			sy--;
			isteps++;
		}
		while (sx > gx && sy < gy)
		{
			sx--;
			sy++;
			isteps++;
		}
		while (sx > gx + 2)
		{
			sx -= 2;
			isteps += 2;
		}
		while (sx < gx - 2)
		{
			sx += 2;
			isteps += 2;
		}
		while (sy > gy + 2)
		{
			sy -= 2;
			isteps += 2;
		}
		while (sy < gy)
		{
			sy++;
			isteps++;
		}

		// the table is precalculated with the results for the 2x2 distance
		int[,] table = new[,]{
			{ 2, 2, 2, 2, 2 },
			{ 3, 1, 1, 1, 3 },
			{ 2, 2, 0, 2, 2 },
			{ 3, 1, 3, 1, 3 },
			{ 2, 4, 2, 4, 2 }
		};
		int dx = gx - sx;
		int dy = sy - gy;
		dx += 2;
		dy += 2;

		return isteps + table[dy, dx];
	}
}
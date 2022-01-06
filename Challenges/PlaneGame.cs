using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PlaneGame
{
	public int bestShot(int[] x, int[] y)
	{
		if (x.Length < 3)
			return x.Length;

		int maxCount = 0;
		for (int i = 0; i < x.Length; i++)
		{
			int x1 = x[i];
			int y1 = y[i];

			for (int j = 0; j < x.Length; j++)
			{
				if (i == j)
					continue;

				int x2 = x[j];
				int y2 = y[j];

				int m1 = (y2 - y1);
				int m2 = (x2 - x1);
				double m = m1 / m2;

				Console.WriteLine("---------------------------------------");
				int count = 2;
				for (int k = 0; k < x.Length; k++)
				{
					if (i == k)
						continue;
					if (j == k)
						continue;


					int x3 = x[k];
					int y3 = y[k];

					int mk1 = (y3 - y1);
					int mk2 = (x3 - x1);
					double mk = mk1 / mk2;

					Console.WriteLine("Going from: {0},{1} to {2},{3} to {4},{5}, m = {6}, mk = {7}",
						x1, y1, x2, y2, x3, y3, m, mk);

					// Parallel
					if (m == mk)
						count++;
					// Perpendicular
					else if (m == -1 / mk)
						count++;
				}

				maxCount = Math.Max(count, maxCount);
			}
		}
		return maxCount;
	}
}

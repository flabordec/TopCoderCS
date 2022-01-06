using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TriangleEasy
{
	public int find(int n, int[] x, int[] y)
	{
		var graph = new bool[n, n];
		for (int i = 0; i < x.Length; i++)
		{
			int xc = x[i];
			int yc = y[i];
			graph[xc, yc] = true;
			graph[yc, xc] = true;
		}

		int best = 3;
		for (int i = 0; i < n; i++)
		{
			for (int j = i + 1; j < n; j++)
			{
				for (int k = j + 1; k < n; k++)
				{
					int need = 0;
					if (!graph[i, j])
						need++;
					if (!graph[i, k])
						need++;
					if (!graph[k, j])
						need++;
					best = Math.Min(best, need);
				}
			}
		}
		return best;
	}
}

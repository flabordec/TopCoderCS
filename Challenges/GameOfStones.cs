using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameOfStones
{
	private void MinMax(int[] stones, out int min, out int max, out int minIx, out int maxIx)
	{
		min = stones.First();
		max = stones.First();
		minIx = 0;
		maxIx = 0;
		for (int i = 0; i < stones.Length; i++)
		{
			if (stones[i] < min)
			{
				min = stones[i];
				minIx = i;
			}

			if (stones[i] > max)
			{
				max = stones[i];
				maxIx = i;
			}
		}
	}

	public int count(int[] stones)
	{
		int moves = 0;
		int min, max, minIx, maxIx;
		while (true)
		{
			MinMax(stones, out min, out max, out minIx, out maxIx);
			bool done = (min == max);
			if (done) break;

			stones[minIx] += 2;
			stones[maxIx] -= 2;

			if (stones[minIx] > stones[maxIx])
				return -1;

			moves++;
		}

		return moves;
	}
}


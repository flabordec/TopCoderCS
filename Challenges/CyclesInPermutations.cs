using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CyclesInPermutations
{
	public int maxCycle(int[] board)
	{
		bool[] visited = new bool[board.Length];
		int max = 0;
		for (int i = 0; i < board.Length; i++)
		{
			if (visited[i])
				continue;

			int x = i;
			int count = 0;
			while (!visited[x])
			{
				visited[x] = true;
				x = board[x] - 1;
				count++;
			}

			if (count > max)
				max = count;
		}
		return max;
	}
}

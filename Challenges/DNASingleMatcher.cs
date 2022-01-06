using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DNASingleMatcher
{
	public int longestMatch(string sequence1, string sequence2)
	{
		int[,] map = new int[sequence1.Length + 1, sequence2.Length + 1];

		int max = 0;
		for (int i = 0; i < sequence1.Length; i++)
		{
			for (int j = 0; j < sequence2.Length; j++)
			{
				if (sequence1[i] == sequence2[j])
				{
					map[i, j] = 1;
					if (i >= 1 && j >= 1)
						map[i, j] += map[i - 1, j - 1];
					if (max < map[i, j])
						max = map[i, j];
				}
			}
		}
		return max;
	}

	
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PiecewiseLinearFunctionDiv2
{
	public int[] countSolutions(int[] Y, int[] query)
	{
		int[] solutions = new int[query.Length];
		for (int qIx = 0; qIx < query.Length; qIx++)
		{
			int q = query[qIx];
			for (int yIx = 0; yIx < Y.Length - 1; yIx++)
			{
				int curr = Y[yIx];
				int next = Y[yIx + 1];

				if (curr == q && next == q)
				{
					solutions[qIx] = -1;
					break;
				}
				else if ((curr >= q && q > next) ||
					(curr <= q && q < next))
				{
					//Console.WriteLine("Query {0} found from {1} to {2}", q, curr, next);
					solutions[qIx]++;
				}
			}
			if (solutions[qIx] != -1 && Y[Y.Length - 1] == q)
			{
				//Console.WriteLine("Query {0} found at final point {1}", q, Y[Y.Length -1 ]);
				solutions[qIx]++;
			}
		}
		//Console.WriteLine(string.Join(",", solutions));
		return solutions;
	}
}

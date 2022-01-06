using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeForces
{
	public class UVA00001_3nP1
	{
		const int N = 10000;
		static int[] dp = new int[N];

		public static int Solve(int n, int m)
		{
			int max = 0;
			// n = 1, m = 20
			
			// max = max(max, ranges[0])
			// n = 11, m = 22
			// max = max(max, ranges[1])
			// n = 21, m = 22

			for (int i = n; i <= m; i++)
			{
				int length = CycleLengthRecursive(i);
				max = Math.Max(length, max);
			}
			
			return max;
		}

		static int CycleLengthRecursive(int n)
		{
			if (n < N && dp[n] != 0)
				return dp[n];
			else
			{
				if (n == 1)
					return 1;

				int m;
				if ((n & 1) != 0)
					m = 3 * n + 1;
				else
					m = n >> 1;

				int length = 1 + CycleLengthRecursive(m);
				if (n < N)
					dp[n] = length;
				return length;
			}
		}
	}
}

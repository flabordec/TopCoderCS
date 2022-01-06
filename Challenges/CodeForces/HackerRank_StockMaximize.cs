using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Solution_StockMaximize
{
	class Solution
	{
		static void Main(string[] args)
		{
			int T = int.Parse(Console.ReadLine());
			for (int t = 0; t < T; t++)
			{
				int N = int.Parse(Console.ReadLine());
				long[] prices =
					Console.ReadLine().Split(' ').Select(p => long.Parse(p)).ToArray();

				long money = 0;
				long spent = 0;
				int maxIx = prices.Length - 1;
				int ix = prices.Length - 2;
				while (ix >= 0)
				{
					while (ix >= 0 && prices[ix] <= prices[maxIx])
					{
						spent += prices[ix];
						ix--;
					}

					int count = maxIx - ix - 1;
					money += (long)prices[maxIx] * count;
					money -= spent;
					Console.Error.WriteLine(
						$"Selling at ${prices[maxIx]} (ix: {maxIx}) {count} items (spent: {spent})");
					spent = 0;

					maxIx = ix;
					ix--;
				}
				Console.WriteLine(money);
			}
		}
	}
}

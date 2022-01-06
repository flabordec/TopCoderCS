using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DimaAndStaircase_272C
{
	static void Main(string[] args)
	{
		int n = int.Parse(Console.ReadLine());
		int[] stairs = new int[n];

		string[] line = Console.ReadLine().Split(' ');

		for (int i = 0; i < n; i++)
			stairs[i] = int.Parse(line[i]);

		int m = int.Parse(Console.ReadLine());

		long L = 0;
		long h1 = 0;
		for (int t = 0; t < m; t++)
		{
			line = Console.ReadLine().Split(' ');
			long w2 = long.Parse(line[0]);
			long h2 = long.Parse(line[1]);

			L = Math.Max(L + h1, stairs[w2 - 1]);

			Console.WriteLine(L);

			h1 = h2;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Underprimes
{
	public int howMany(int A, int B)
	{
		int[] factors = new int[B+1];
		for (int i = 0; i <= B; i++)
			factors[i] = 1;

		for (int i = 2; i <= B; i++)
		{
			if (factors[i] == 1)
			{
				factors[i] = i;
				for (int j = i + i, counter = 1; j <= B; j += i, counter++)
					factors[j] = i;
			}
		}

		int totalCount = 0;
		for (int i = A; i <= B; i++)
		{
			int n = i;
			int count = 0;
			Console.Write("{0} ", n);
			while (n > 1)
			{
				Console.Write("/ {0} ", factors[n]);

				n /= factors[n];
				count++;
			}
			Console.WriteLine("= {0}", count);

			if (factors[count] == count && count != 1)
				totalCount++;
		}
		return totalCount;
	}
}

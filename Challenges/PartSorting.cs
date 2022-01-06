using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PartSorting
{
	public int[] process(int[] data, int nSwaps)
	{
		int ix = 0;
		while (nSwaps > 0 && ix < data.Length)
		{
			int len = Math.Min(data.Length - ix, nSwaps + 1);

			int maxIx = ix;
			for (int i = ix + 1; i < ix + len; i++)
			{
				if (data[maxIx] < data[i])
					maxIx = i;
			}

			int currSwaps = maxIx - ix;
			for (int i = ix + currSwaps; i > ix; i--)
			{
				int temp = data[i];
				data[i] = data[i - 1];
				data[i - 1] = temp;
			}
			nSwaps -= currSwaps;

			//Console.WriteLine("Selected {0}, swaps left {1}, array: {2}", data[ix], nSwaps, string.Join(", ", data));

			ix++;
		}

		Console.WriteLine(string.Join(", ", data));
		return data;
	}
}

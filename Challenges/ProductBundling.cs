using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProductBundling
{
	public int howManyBundles(string[] data)
	{
		long[] purchases = new long[data[0].Length];
		for (int i = 0; i < data.Length; i++)
		{
			for (int j = 0; j < data[i].Length; j++)
			{
				if (data[i][j] == '1')
					purchases[j] |= 1L << i;
			}
		}
		return purchases.Distinct().Count();
	}
}

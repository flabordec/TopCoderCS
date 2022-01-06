using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BinPackingEasy
{
	public int minBins(int[] item)
	{
		List<int> items = new List<int>(item);
		items.Sort((i, j) => j - i);

		List<int> bins = new List<int>();
		bins.Add(0);

		foreach (int it in items)
		{
			bool foundBin = false;
			for (int i = 0; i < bins.Count; i++)
			{
				if (bins[i] + it <= 300)
				{
					foundBin = true;
					bins[i] += it;
					break;
				}
			}
			if (!foundBin)
				bins.Add(it);
		}
		return bins.Count;
	}
}

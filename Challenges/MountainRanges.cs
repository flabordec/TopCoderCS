using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MountainRanges
{
	public int countPeaks(int[] heights)
	{
		int numPeaks = 0;
		for (int i = 0; i < heights.Length; i++)
		{
			bool peak = true;
			if (i > 0 && heights[i] <= heights[i - 1])
			{
				peak = false;
			}
			if (i < heights.Length - 1 && heights[i] <= heights[i + 1])
			{
				peak = false;
			}

			if (peak)
				numPeaks++;
		}

		return numPeaks;
	}
}

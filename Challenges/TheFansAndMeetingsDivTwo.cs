using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TheFansAndMeetingsDivTwo
{
	public double find(int[] minJ, int[] maxJ, int[] minB, int[] maxB)
	{
		double[] noFansJ = new double[52];
		double[] noFansB = new double[52];
		for (int k = 1; k <= 50; k++)
		{
			for (int i = 0; i < minJ.Length; i++)
			{
				if (minJ[i] <= k && maxJ[i] >= k)
					noFansJ[k] += 1.0 / (maxJ[i] - minJ[i] + 1);
				if (minB[i] <= k && maxB[i] >= k)
					noFansB[k] += 1.0 / (maxB[i] - minB[i] + 1);
			}
			noFansJ[k] /= minJ.Length;
			noFansB[k] /= minB.Length;
		}
		double prob = 0;
		for (int i = 1; i <= 50; i++)
			prob += noFansJ[i] * noFansB[i];

		return prob;
	}
}

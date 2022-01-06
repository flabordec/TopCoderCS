using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PriorityQueue
{
	public int findAnnoyance(string S, int[] a)
	{
		int totalDispleasure = 0;
		int currentHate = 0;
		for (int i = 0; i < S.Length; i++)
		{
			if (S[i] == 'b')
				totalDispleasure += currentHate;
			
			currentHate += a[i];
		}
		return totalDispleasure;
	}
}

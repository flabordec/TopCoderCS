using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ShoppingSurveyDiv2
{
	public int minValue(int N, int[] s)
	{
		int totalProds = s.Sum();

		for (int i = 0; i < N; i++)
		{
			Array.Sort(s);
			for (int j = 1; j < s.Length; j++)
			{
				s[j]--;
				totalProds--;
			}
			if (totalProds <= 0)
				return 0;
		}
		return totalProds;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RogersPhenomenon
{
	public int countTriggers(int[] set1, int[] set2)
	{
		double average1 = set1.Average();
		double average2 = set2.Average();

		int count = 0;
		for (int i = 0; i < set1.Length; i++)
		{
			if (set1[i] < average1 && set1[i] > average2)
			{
				count++;
				Console.WriteLine("{0} in set 1", set1[i]);
			}
		}
		for (int i = 0; i < set2.Length; i++)
		{
			if (set2[i] < average2 && set2[i] > average1)
			{
				count++;
				Console.WriteLine("{0} in set 2", set2[i]);
			}
		}
		return count;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MakingPairs
{
	public int get(int[] card)
	{
		int sum = 0;
		foreach (int c in card)
		{
			sum += c / 2;
		}
		return sum;
	}
}

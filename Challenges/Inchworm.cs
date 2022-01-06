using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Inchworm
{
	public int lunchtime(int branch, int rest, int leaf)
	{
		int cLeaf = 0;
		int lunch = 0;
		for (int i = 0; i <= branch; i += rest)
		{
			while (cLeaf < i)
				cLeaf += leaf;
			Console.WriteLine("Resting at {0}, next food {1}", i, cLeaf);

			if (i == cLeaf)
			{
				Console.WriteLine("Make lunch");
				lunch++;
			}
		}
		return lunch;
	}
}

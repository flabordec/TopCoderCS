using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LuckyXor
{
	public int construct(int a)
	{
		int[] lucky = new[]{
			4, 7, 44, 47, 74, 77
		};

		for (int i = a + 1; i <= 100; i++)
		{
			if (lucky.Contains(i ^ a))
				return i;
		}
		return -1;
	}
}
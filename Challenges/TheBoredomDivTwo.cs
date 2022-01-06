using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TheBoredomDivTwo
{
	public int find(int n, int m, int j, int b)
	{
		int bored = n;
		if (j - 1 >= n)
			bored++;
		if (b - 1 >= n)
			bored++;
		return bored;
	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TriangleMaking
{
	public int maxPerimeter(int a, int b, int c)
	{
		int maxPerimeter = 0;

		for (int pA = 0; pA <= a; pA++)
		for (int pB = 0; pB <= b; pB++)
		for (int pC = 0; pC <= c; pC++)
		{
			if (isTriangle(pA, pB, pC))
			{
				int perimeter = pA + pB + pC;
				maxPerimeter = Math.Max(maxPerimeter, perimeter);
			}
		}
		return maxPerimeter;
	}

	private bool isTriangle(int i, int j, int k)
	{
		return
			i + j > k &&
			i + k > j &&
			j + k > i;
	}
}

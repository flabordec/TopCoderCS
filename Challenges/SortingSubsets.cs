using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SortingSubsets
{
	public int getMinimalSize(int[] a)
	{
		int[] aSorted = new int[a.Length];
		Array.Copy(a, aSorted, a.Length);
		Array.Sort(aSorted);

		int count = 0;
		for (int i = 0; i < a.Length; i++)
			if (a[i] != aSorted[i])
				count++;

		return count;
	}
}

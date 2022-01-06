using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SuperUserDo
{
	public int install(int[] A, int[] B)
	{
		HashSet<int> deps = new HashSet<int>();
		for (int i = 0; i < A.Length; i++)
		{
			int start = A[i];
			int end = B[i];
			for (int j = start; j <= end; j++)
				deps.Add(j);
		}
		return deps.Count;
	}
}

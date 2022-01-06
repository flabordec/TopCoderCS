using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DifferentStrings
{
	public int minimize(string A, string B)
	{
		int minDiff = B.Length;
		for (int b = 0; b <= B.Length - A.Length; b++)
		{
			int currentDiff = 0;
			for (int a = 0; a < A.Length; a++)
			{
				int ia = a;
				int ib = b + a;
				//Console.WriteLine("{0} {1}", B[ib], A[ia]);
				if (B[ib] != A[ia])
					currentDiff++;
			}

			//Console.WriteLine("{0} => {1}", b, currentDiff);
			minDiff = Math.Min(currentDiff, minDiff);
		}
		return minDiff;
	}
}

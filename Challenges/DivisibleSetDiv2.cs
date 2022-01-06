using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DivisibleSetDiv2
{
	public string isPossible(int[] b)
	{
		int LCM = 2520;
		int sum = 0;
		foreach (int bi in b)
			sum += LCM / bi;
		return (sum <= LCM) ? "Possible" : "Impossible";
	}
}

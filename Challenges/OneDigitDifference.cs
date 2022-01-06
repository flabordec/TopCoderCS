using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OneDigitDifference
{
	public int getSmallest(int N)
	{
		if (N == 0)
			return 1;
		else if (N < 10)
			return 0;

		string nStr = N.ToString();
		return int.Parse(nStr.Substring(1));
	}
}
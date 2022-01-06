using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BearPasswordAny
{
	public string findPassword(int[] x)
	{
		StringBuilder result = new StringBuilder();
		bool nextA = true;
		for (int i = x.Length - 1; i >= 0; i--)
		{
			while (x[i] > 0)
			{
				char nextChar = nextA ? 'a' : 'b';
				nextA = !nextA;
				result.Append(nextChar, i + 1);
				int sub = 1;
				for (int j = i; j >= 0; j--)
				{
					x[j] -= sub;
					sub++;
				}
			}

			//Console.WriteLine(result.ToString());
			//Console.WriteLine(string.Join(" ", x));

			if (x[i] < 0)
				return string.Empty;

			if (result.Length > x.Length)
				return string.Empty;
		}

		if (result.Length < x.Length)
			return string.Empty;
		else
			return result.ToString();
	}
}
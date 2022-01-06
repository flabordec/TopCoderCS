using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ParenthesesDiv2Medium
{
	public int[] correct(string s)
	{
		List<int> changes = new List<int>();

		char[] sc = s.ToCharArray();
		if (sc[0] == ')')
		{
			sc[0] = '(';
			changes.Add(0);
		}
		if (sc[sc.Length - 1] == '(')
		{
			sc[sc.Length - 1] = ')';
			changes.Add(sc.Length - 1);
		}

		
		int open = 0;
		for (int i = 0; i < sc.Length; i++)
		{
			int maxOpen = (sc.Length - i + 1) / 2;

			if (sc[i] == '(')
			{
				if (open < maxOpen)
				{
					open++;
				}
				else
				{
					sc[i] = ')';
					changes.Add(i);
					open--;
				}
			}
			else if (sc[i] == ')')
			{
				if (open > 0)
				{
					open--;
				}
				else
				{
					sc[i] = '(';
					changes.Add(i);
					open++;
				}
			}
		}
		return changes.ToArray();
	}
}

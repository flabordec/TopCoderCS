using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ParenthesesDiv2Easy
{
	public int getDepth(string s)
	{
		int depth = 0;
		int maxDepth = 0;
		for (int i = 0; i < s.Length; i++)
		{
			if (s[i] == '(')
				depth++;
			if (s[i] == ')')
				depth--;
			maxDepth = Math.Max(depth, maxDepth);
		}
		return maxDepth;
	}
}
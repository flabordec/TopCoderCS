using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EllysSubstringSorter
{
	public string getMin(string S, int L)
	{
		string min = MagicSort(S, L, 0);
		for (int i = 1; i < S.Length - L + 1; i++)
		{
			string curr = MagicSort(S, L, i);
			if (curr.CompareTo(min) < 0)
				min = curr;
		}
		
		return min;
	}

	private string MagicSort(string str, int l, int i)
	{
		string prefix = str.Substring(0, i);
		string substr = str.Substring(i, l);
		string postfix = str.Substring(i + l);

		char[] substrArr = substr.ToCharArray();
		Array.Sort(substrArr);
		substr = new string(substrArr);

		return prefix + substr + postfix;
	}
}


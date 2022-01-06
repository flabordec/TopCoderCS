using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class ErasingCharacters
{
	public string simulate(string s)
	{
		StringBuilder str = new StringBuilder(s);
		
		for (int i = 0; i < str.Length - 1; i++)
		{
			if (str[i] == str[i + 1])
			{
				str.Remove(i, 2);
				i = -1;
			}
		}

		return str.ToString();
	}
}


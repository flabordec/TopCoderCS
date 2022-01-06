using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SubstitutionCipher
{
	public string decode(string a, string b, string y)
	{
		HashSet<char> lettersA = new HashSet<char>();
		HashSet<char> lettersB = new HashSet<char>();
		for (char c = 'A'; c <= 'Z'; c++)
		{
			lettersA.Add(c);
			lettersB.Add(c);
		}

		Dictionary<char, char> table = new Dictionary<char, char>();
		for (int i = 0; i < a.Length; i++)
		{
			char aChar = a[i];
			char bChar = b[i];
			if (table.ContainsKey(bChar))
			{
				if (table[bChar] != aChar)
					return string.Empty;
			}
			else
			{
				table.Add(bChar, aChar);
			}
			lettersA.Remove(aChar);
			lettersB.Remove(bChar);
		}

		if (lettersA.Count == 1)
		{
			char aChar = lettersA.Single();
			char bChar = lettersB.Single();
			if (table.ContainsKey(bChar))
			{
				if (table[bChar] != aChar)
					return string.Empty;
			}
			else
			{
				table.Add(bChar, aChar);
			}
		}

		StringBuilder builder = new StringBuilder(y.Length);
		foreach (char c in y)
		{
			if (table.ContainsKey(c))
				builder.Append(table[c]);
			else
				return string.Empty;
		}
		return builder.ToString();
	}
}

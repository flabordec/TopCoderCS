using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AppleWord
{
	public int minRep(string word)
	{
		if (word.Length < 5)
			return -1;

		word = word.ToLower();

		int count = 0;
		if (word[0] != 'a')
			count++;

		for (int i = 1; i < word.Length - 2; i++)
			if (word[i] != 'p')
				count++;

		if (word[word.Length - 2] != 'l')
			count++;

		if (word[word.Length - 1] != 'e')
			count++;

		return count;
	}
}


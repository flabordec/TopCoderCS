using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Plusonegame
{
	public string getorder(string s)
	{
		int[] cards = new int[10];
		int counters = 0;
		for (int i = 0; i < s.Length; i++)
		{
			if (s[i] == '+')
				counters++;
			else
				cards[s[i] - '0']++;
		}

		StringBuilder result = new StringBuilder();
		for (int i = 0; i < 10; i++)
		{
			while (cards[i] > 0)
			{
				result.Append(i);
				cards[i]--;
			}

			if (counters > 0)
			{
				result.Append('+');
				counters--;
			}
		}
		while (counters > 0)
		{
			result.Append('+');
			counters--;
		}

		return result.ToString();
	}
}

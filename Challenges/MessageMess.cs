using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class MessageMess
{
	public string restore(string[] dictionary, string message)
	{
		string[] results = new string[message.Length + 1];
		int[] memo = new int[message.Length + 1];
		memo[0] = 1;

		for (int i = 0; i < message.Length; i++)
		{
			foreach (string word in dictionary)
			{
				if (i - word.Length + 1 >= 0 && // If the word fits in the current message substring
					message.Substring(i - word.Length + 1, word.Length).Equals(word) && // and the word equals the current message substring
					memo[i - word.Length + 1] > 0) // and I have a possible combination in the previous index
				{
					memo[i + 1] += memo[i - word.Length + 1];
					results[i + 1] = word;
				}
			}
		}

		if (memo[message.Length] == 1)
		{
			int ix = message.Length;
			StringBuilder result = new StringBuilder();
			while (ix > 0)
			{
				result.Insert(0, " " + results[ix]);
				ix -= results[ix].Length;
			}
			return result.Remove(0, 1).ToString();
		}
		else if (memo[message.Length] == 0)
		{
			return "IMPOSSIBLE!";
		}
		else
		{
			return "AMBIGUOUS!";
		}
	}
}


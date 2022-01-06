using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CyclicWords
{
	public int differentCW(string[] words)
	{
		HashSet<string> resultWords = new HashSet<string>();
		foreach (string word in words)
		{
			bool found = false;
			foreach (string resultWord in resultWords)
			{
				if (CyclicEqual(word, resultWord))
				{
					found = true;
					break;
				}
			}
			if (!found)
				resultWords.Add(word);
		}
		return resultWords.Count;
	}

	private bool CyclicEqual(string word, string resultWord)
	{
		if (word.Length != resultWord.Length)
			return false;

		for (int offset = 0; offset < resultWord.Length; offset++)
		{
			if (OneCycleEqual(word, resultWord, offset))
				return true;
		}
		return false;
	}

	private bool OneCycleEqual(string word, string resultWord, int offset)
	{
		for (int i = 0; i < resultWord.Length; i++)
		{
			int j = (i + offset) % word.Length;
			if (word[i] != resultWord[j])
				return false;
		}
		return true;
	}
}

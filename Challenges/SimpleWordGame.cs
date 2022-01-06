using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SimpleWordGame
{
	public int points(string[] player, string[] dictionary)
	{
		HashSet<string> dictionarySet = new HashSet<string>(dictionary);
		int totalScore = 0;
		foreach (string word in player.Distinct())
		{
			if (dictionarySet.Contains(word))
				totalScore += word.Length * word.Length;
		}
		return totalScore;
	}
}

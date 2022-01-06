using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution_MakingAnagrams
{

	static int makingAnagrams(string s1, string s2)
	{
		int[] letterCounts = new int['z' - 'a' + 1];
		// Complete this function
		foreach (char c in s1)
			letterCounts[c - 'a']++;
		foreach (char c in s2)
			letterCounts[c - 'a']--;

		int result = 0;
		foreach (int letterCount in letterCounts)
			result += Math.Abs(letterCount);
		return result;
	}

	static void Main(String[] args)
	{
		string s1 = Console.ReadLine();
		string s2 = Console.ReadLine();
		int result = makingAnagrams(s1, s2);
		Console.WriteLine(result);
	}
}

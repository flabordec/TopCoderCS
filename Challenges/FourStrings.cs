using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FourStrings
{
	public int shortestLength(string a, string b, string c, string d)
	{
		string result = ShortestString(new HashSet<string>() { a, b, c, d }, 0, "");
		Console.WriteLine(result);
		return result.Length;
	}

	public string ShortestString(HashSet<string> stringsToMerge, int i, string result)
	{
		if (!stringsToMerge.Any())
		{
			return result;
		}
		else
		{
			string bestResult = null;
			foreach (string stringToMerge in stringsToMerge.ToArray())
			{
				stringsToMerge.Remove(stringToMerge);
				if (result.ToString().Contains(stringToMerge))
				{
					string nr = ShortestString(stringsToMerge, i + 1, result);
					if (bestResult == null || bestResult.Length > nr.Length)
						bestResult = nr;
				}
				else
				{
					string r1 = MergeStringsLeft(result, stringToMerge);
					string mr1 = ShortestString(stringsToMerge, i + 1, r1);
					if (bestResult == null || bestResult.Length > mr1.Length)
						bestResult = mr1;

					string r2 = MergeStringsRight(result, stringToMerge);
					string mr2 = ShortestString(stringsToMerge, i + 1, r2);
					if (bestResult == null || bestResult.Length > mr2.Length)
						bestResult = mr2;
				}
				stringsToMerge.Add(stringToMerge);
			}
			return bestResult;
		}
	}

	public string MergeStringsLeft(string a, string b)
	{
		int max = 0;
		for (int i = 1; i < a.Length; i++)
		{
			string substr = a.Substring(0, i);
			if (b.EndsWith(substr))
				max = i;
		}
		return b + a.Substring(max);
	}
	public string MergeStringsRight(string a, string b)
	{
		int max = 0;
		for (int i = 1; i < b.Length; i++)
		{
			string substr = b.Substring(0, i);
			if (a.EndsWith(substr))
				max = i;
		}
		return a + b.Substring(max);
	}
}

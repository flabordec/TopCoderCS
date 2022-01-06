using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Solution_SherlockAndAnagrams
{
	private const int MAX = 'z' - 'a' + 1;

	static bool IsAnagram(int[] count1, int[] count2)
	{
		for (int i = 0; i < MAX; i++)
		{
			if (count1[i] != count2[i])
				return false;
		}
		return true;
	}

	static int FindPair(string str, int start, char[] tmp, int tmpLength)
	{
		int strLength = str.Length;
		if (tmpLength > strLength - start)
		{
			return 0;
		}

		int[] count1 = new int[MAX];
		int[] count2 = new int[MAX];
		int cnt = 0;
		int i;
		for (i = 0; i < MAX; i++)
		{
			count1[i] = 0;
			count2[i] = 0;
		}

		for (i = 0; i < tmpLength && (start + i) < strLength; i++)
		{
			count1[tmp[i] - 'a']++;
			count2[str[start + i] - 'a']++;
		}

		int j;
		for (j = start + i; j < strLength; j++)
		{
			if (IsAnagram(count1, count2))
			{
				cnt++;
			}
			count2[str[start] - 'a']--;
			count2[str[j] - 'a']++;
			start++;
		}
		if (j == strLength)
		{
			if (IsAnagram(count1, count2))
			{
				cnt++;
			}
		}

		return cnt;
	}

	static int SherlockAndAnagrams(string str)
	{
		int n = str.Length;
		if (n < 2)
		{
			return 0;
		}

		int cnt = 0;
		char[] tmp = new char[n + 1];
		for (int i = 0; i < n; i++)
		{
			int k = 0;
			for (int j = i; j < n; j++)
			{
				tmp[k] = str[j];

				cnt += FindPair(str, i + 1, tmp, k + 1);
				k++;
			}
		}
		return cnt;
	}


	static void Main(String[] args)
	{
		int q = Convert.ToInt32(Console.ReadLine());
		for (int a0 = 0; a0 < q; a0++)
		{
			string s = Console.ReadLine();
			int result = Solution_SherlockAndAnagrams.SherlockAndAnagrams(s);
			Console.WriteLine(result);
		}
	}
}
